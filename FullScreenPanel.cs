using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
    public partial class FullScreenPanel : UserControl
    {
        public FullScreenPanel()
        {
            InitializeComponent();
        }


        private void btnCloseFullScreen_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void FullScreenPanel_Leave(object sender, EventArgs e)
        {
            
        }

        private void FullScreenPanel_MouseLeave(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
