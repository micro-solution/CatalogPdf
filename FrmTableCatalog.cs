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
                setTable();
                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetData()
        {
            //  List<XMLDBLib.Document> docs = presenter.Catalog.Documents.OrderBy(a => a.Tome).ThenBy(b => b.StartPage).ToList();          
            dataGridView1.DataSource = CatalogDocs.Catalog.OrderBy(a => a.Tome).ThenBy(b => b.StartPage).ToList();
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string path = dataGridView1.Rows[row].Cells[6].Value.ToString();

            XMLDBLib.Document doc = presenter.Catalog.GetByPath(path);

            if (doc != null)
            {
                int.TryParse(dataGridView1.Rows[row].Cells[2].Value.ToString(), out int tome);
                switch (e.ColumnIndex)
                {
                    case 1:
                        int.TryParse(dataGridView1.Rows[row].Cells[1].Value.ToString(), out int number);
                        doc.Number = number;
                        break;
                    case 2:
                        //  int.TryParse(dataGridView1.Rows[row].Cells[2].Value.ToString(), out int tome);
                        doc.Tome = tome;
                        break;
                    case 3:
                        string name = dataGridView1.Rows[row].Cells[3].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(name)) doc.Name = name;
                        break;
                    case 4:
                        DateTime.TryParse(dataGridView1.Rows[row].Cells[4].Value.ToString(), out DateTime date);
                        doc.Date = date;
                        break;
                    case 5:
                        string type = dataGridView1.Rows[row].Cells[5].Value.ToString();
                        if (!string.IsNullOrWhiteSpace(type)) doc.DocType = type;
                        break;
                    case 7:
                        int.TryParse(dataGridView1.Rows[row].Cells[7].Value.ToString(), out int startPage);

                        if (startPage != 0)
                        {
                            int.TryParse(dataGridView1.Rows[row].Cells[9].Value.ToString(), out int amount);
                            int endPage = startPage + amount - 1;
                            dataGridView1.Rows[row].Cells[8].Value = endPage;
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

        private void setTable()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(242, 249, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(237, 246, 255);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;  //HeaderText = "Код";
            dataGridView1.Columns[0].Width = 0;

            dataGridView1.Columns[1].HeaderText = "Номер";
            dataGridView1.Columns[1].Width = 45;

            dataGridView1.Columns[2].HeaderText = "Том";
            dataGridView1.Columns[2].Width = 36;

            dataGridView1.Columns[3].HeaderText = "Название";
            dataGridView1.Columns[3].Width = 200;

            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[4].Width = 65;

            dataGridView1.Columns[5].HeaderText = "Тип";
            dataGridView1.Columns[5].Width = 100;

            dataGridView1.Columns[6].HeaderText = "Путь";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[6].

            dataGridView1.Columns[7].HeaderText = "Начало";
            dataGridView1.Columns[7].Width = 45;

            dataGridView1.Columns[8].HeaderText = "Конец";
            dataGridView1.Columns[8].Width = 45;

            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Страниц";
            dataGridView1.Columns[9].Width = 0;


            DataGridViewCellStyle linkStyle = new DataGridViewCellStyle();
            linkStyle.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
            linkStyle.ForeColor = Color.DarkBlue;
            dataGridView1.Columns[6].DefaultCellStyle = linkStyle;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            presenter.Save();
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex > 0)
            {
                string path = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (File.Exists(path))
                {
                    Process.Start(path);
                }
            }
        }

        private void btnNumerDocumentByPage_Click(object sender, EventArgs e)
        {
            SortedSet<int> tomes = presenter.GetAllTomsNumbers();
            foreach (int tom in tomes)
            {
                List<XMLDBLib.Document> docs = presenter.Catalog.Documents.Where(x=> x.Tome ==tom).OrderBy(b => b.StartPage).ToList();
                int i=1;
                docs.ForEach(n => n.Number = i++);
            }
            presenter.Save();
            GetData();
        }

    
    }
}
