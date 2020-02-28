using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
    public partial class FrmTableCatalog : Form
    {
        internal DataPresenter presenter;

        private CatalogDocuments CatalogDocs
        {
            get
            {
                if (_catalog == null)
                {
                    _catalog = new CatalogDocuments();
                }
                return _catalog;
            }
        }
        private CatalogDocuments _catalog;
        public FrmTableCatalog()
        {
            InitializeComponent();
            Width = 900;
            Height = 400;
            DialogResult = DialogResult.None;

            info = new Label();
            Controls.Add(info);
            info.Name = "Lb_info";
            info.Text = "";
            info.AutoSize = true;
            info.Visible = false;
            info.Top = dataGridView1.Top + dataGridView1.Height + 10;
            info.Left = 10;
            info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            info.ForeColor = Color.Red;
        }
        Label info;

        public void SetDataGreed()
        {
            try
            {
                GetData();
                SetTable();
                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetData()
        {
            //List<XMLDBLib.Document> docs = presenter.Catalog.Documents.OrderBy(a => a.Tome).ThenBy(b => b.StartPage).ToList();           
            dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.Tome).ThenBy(b => b.StartPage).ToList(); ;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string path = dataGridView1.Rows[row].Cells[GetNumberColumn("Путь")].Value.ToString();

            XMLDBLib.Document doc = presenter.Catalog.GetByPath(path);

            if (doc != null)
            {
                int.TryParse(dataGridView1.Rows[row].Cells[GetNumberColumn("Том")].Value.ToString(), out int tome);
                switch (dataGridView1.Columns[e.ColumnIndex].HeaderText)
                {
                    case "Номер"://1:
                        int.TryParse(dataGridView1.Rows[row].Cells[GetNumberColumn("Номер")].Value.ToString(), out int number);
                        doc.Number = number;
                        break;
                    case "Том"://2:                       
                        doc.Tome = tome;
                        break;
                    case "Название"://6:
                        string name = dataGridView1.Rows[row].Cells[GetNumberColumn("Название")].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(name)) doc.Name = name;
                        break;
                    case "Дата"://8:
                        DateTime.TryParse(dataGridView1.Rows[row].Cells[GetNumberColumn("Дата")].Value.ToString(), out DateTime date);
                        doc.Date = date;
                        break;
                    case "Тип"://7:
                        string type = dataGridView1.Rows[row].Cells[GetNumberColumn("Тип")].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(type)) doc.DocType = type;
                        break;
                    case "Начало"://3:
                        int.TryParse(dataGridView1.Rows[row].Cells[GetNumberColumn("Начало")].Value.ToString(), out int startPage);

                        if (startPage != 0)
                        {
                            int.TryParse(dataGridView1.Rows[row].Cells[GetNumberColumn("Страниц")].Value.ToString(), out int amount);
                            int endPage = startPage + amount - 1;
                            dataGridView1.Rows[row].Cells[GetNumberColumn("Конец")].Value = endPage;
                            doc.StartPage = startPage;
                            doc.EndPage = endPage;
                            if (presenter.isFreeRangePage(startPage, endPage, tome, path))
                            {
                                info.Visible = false;
                                info.Text = "";
                            }
                            else
                            {
                                info.Visible = true;
                                info.Text = "Внимание! пересечение диапазонов страниц.";
                            }
                        }

                        break;

                    default:
                        break;
                }
                GetData();
                // dataGridView1.Update();
            }
        }

        private void SetTable()
        {
            int i = 0;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(242, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(237, 246, 255);
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[i].Visible = false;  //HeaderText = "Код"; //№0
            dataGridView1.Columns[i].Width = 0;

            dataGridView1.Columns[++i].HeaderText = "Номер";//№1
            dataGridView1.Columns[i].Width = 45;

            dataGridView1.Columns[++i].HeaderText = "Том";//№2
            dataGridView1.Columns[i].Width = 36;
            //dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;


            dataGridView1.Columns[++i].HeaderText = "Начало";//№3
            dataGridView1.Columns[i].Width = 45;
            // dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[++i].HeaderText = "Конец";//№4
            dataGridView1.Columns[i].Width = 45;

            dataGridView1.Columns[++i].Visible = false;
            dataGridView1.Columns[i].HeaderText = "Страниц";//№5
            dataGridView1.Columns[i].Width = 0;

            dataGridView1.Columns[++i].HeaderText = "Название";//№6
            dataGridView1.Columns[i].Width = 200;
            //dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[++i].HeaderText = "Тип";//№7
            dataGridView1.Columns[i].Width = 120;
            //  dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[++i].HeaderText = "Дата";//№8
            dataGridView1.Columns[i].Width = 85;
            //  dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[++i].HeaderText = "Путь";//№9
            dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewCellStyle linkStyle = new DataGridViewCellStyle();
            linkStyle.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
            linkStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[GetNumberColumn("Путь")].DefaultCellStyle = linkStyle;



        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            presenter.Save();
            Close();
        }


        private int GetNumberColumn(string title)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.HeaderText == title) return col.Index;
            }
            MessageBox.Show($"Столбец {title} не найден");
            return 0;
        }


        private void btnNumerDocumentByPage_Click(object sender, EventArgs e)
        {
            SortedSet<int> tomes = presenter.GetAllTomsNumbers();
            foreach (int tom in tomes)
            {
                List<XMLDBLib.Document> docs = presenter.Catalog.Documents.Where(x => x.Tome == tom).OrderBy(b => b.StartPage).ToList();
                int i = 1;
                docs.ForEach(n => n.Number = i++);
            }
            presenter.Save();
            GetData();
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                string header = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                if (header.Contains("Путь"))
                {
                    dataGridView1.Cursor = Cursors.Hand;
                }
            }

        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Cursor = Cursors.Default;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string header = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            if (header.Contains("Путь"))
            {
                string path = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (File.Exists(path))
                {
                    Process.Start(path);
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 6 && e.RowIndex > 0)
            //{
            //    string path = dataGridView1.Rows[e.RowIndex].Cells[GetNumberColumn("Путь")].Value.ToString();
            //    if (File.Exists(path))
            //    {
            //        Process.Start(path);
            //    }
            //}
        }

        /// <summary>
        /// Сортировка при нажатии на заголовок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            string title = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            switch (title)
            {
                case "Номер"://1:
                    dataGridView1.DataSource  = CatalogDocs.Catalog.OrderBy(a => a.Number).ThenBy(b => b.StartPage).ToList();
                    break;
                case "Тип"://1:
                    dataGridView1.DataSource  = CatalogDocs.Catalog.OrderBy(a => a.DocType).ThenBy(b => b.StartPage).ToList();
                    break;
                case "Путь"://1:
                    dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.FullName).ThenBy(b => b.StartPage).ToList();
                    break;
                case "Название"://1:
                    dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.Name).ThenBy(b => b.StartPage).ToList();
                    break;
                case "Дата"://1:
                    dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.DateCreate).ThenBy(b => b.StartPage).ToList();
                    break;
                default ://1:
                    dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.Tome).ThenBy(b => b.StartPage).ToList();
                    break;
            }
            
        }

    }
}
