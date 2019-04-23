using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URI_Binder
{
    public partial class URIBinder : Form
    {
        public URIBinder()
        {
            InitializeComponent();
        }

        // We are selecting an app to bind to
        private void appSelectButon_Click(object sender, EventArgs e)
        {
            selectAppDialog.Filter = "exe files (*.exe)|*.exe";
            if (selectAppDialog.ShowDialog() == DialogResult.OK)
            {
                progressLabel.Text = "application specified";
            }
        }
    }
}
