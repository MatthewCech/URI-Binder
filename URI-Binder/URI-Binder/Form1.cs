using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace URI_Binder
{
    public enum BinderState
    {
        Idle,
        Begin,
        BuildURI,
        Bind,
        Done,
    }

    public partial class URIBinder : Form
    {
        BinderState state;

        public URIBinder()
        {
            state = BinderState.Idle;
            InitializeComponent();
        }

        // Internal to create keys
        private string CreateURIBind()
        {
            return "";
        }

        // We are selecting an app to bind to
        private void appSelectButon_Click(object sender, EventArgs e)
        {
            selectAppDialog.Filter = "exe files (*.exe)|*.exe";

            if (selectAppDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = selectAppDialog.FileName;

                progressLabel.Text = "App specified: " + filePath;
                appSelectText.Text = filePath;
            }
        }

        // This builds the registry string, then outputs it to the file.
        private void createButton_Click(object sender, EventArgs e)
        {
            state = BinderState.Begin;
        }

        // Set state info
        private void setProgress(float which)
        {
            progressLabel.Text = state.ToString();
            progressBar.Value = (int)(which / (Enum.GetNames(typeof(BinderState)).Length - 1) * 100);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch(state)
            {
                case BinderState.Idle:
                    setProgress(0);
                    break;

                case BinderState.Begin:
                    setProgress(1);
                    state = BinderState.BuildURI;
                    break;

                case BinderState.BuildURI:
                    setProgress(2);
                    state = BinderState.Bind;
                    break;

                case BinderState.Bind:
                    setProgress(3);
                    state = BinderState.Done;
                    break;

                case BinderState.Done:
                    setProgress(4);
                    progressLabel.Text = state.ToString();
                    break;
            }
        }
    }
}
