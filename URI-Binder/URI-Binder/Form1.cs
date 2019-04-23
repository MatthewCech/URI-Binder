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
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Security.Principal;

namespace URI_Binder
{
    public enum BinderState
    {
        Idle,
        Begin,
        CreateRootKey,
        CreateDefaultIcon,
        CreateShell,
        CreateURLProtocol,
        Done,
    }

    public partial class URIBinder : Form
    {
        // Variables
        BinderState state = BinderState.Idle;
        string uriExampleEnd = "://args";
        Regex selectWhitespace = new Regex(@"\s+");

        // Registry stuff
        const string classesRoot = "HKEY_CLASSES_ROOT";
        const string sep = "\\";
        const string rootKey = classesRoot + sep + "ztest";
        const string subkey_DefaultIcon = rootKey + sep + "DefaultIcon";
        const string subkey_ShellOpenCommand = rootKey + sep + "shell" + sep + "open" + sep + "command";
        const string subkey_URLProtocol = rootKey + "URL Protocol";

        // Things we need
        string app;
        string uri;
        string filename;

        // Constructor
        public URIBinder()
        {
            InitializeComponent();

            uriSample.Text = uriExampleEnd;
            progressLabel.Text = state.ToString();

            if(!IsAdmin())
            {
                progressLabel.Text = "WAIT! You must run this application as admin!";
                progressLabel.ForeColor = Color.Red;
            }
        }


          ////////////////
         // App events //
        ////////////////

        // We are selecting an app to bind to.
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
            app = appSelectText.Text; // Path to .exe
            uri = cleanURI(uriNameText.Text);

            // Verify input
            if(app.Contains(".exe") && uri.Length > 0 && File.Exists(app) && IsAdmin())
            {
                // Input is good (enough)
                state = BinderState.Begin;
                progressLabel.ForeColor = Color.Gray;
            }
            else
            {
                // Input is bad! Warn the user and do nothing.
                progressLabel.ForeColor = Color.Red;

                if (uri.Length <= 0)
                {
                    progressLabel.Text = "Please specify a URI string!";
                }
                else if (!IsAdmin())
                {
                    progressLabel.Text = "App must be relaunched with admin permissions";
                }
                else
                {
                    progressLabel.Text = "Looks like there's an issue with your application path! Make sure it's a .exe!";
                }
            }
        }

        // When URI is being typed...
        private void uriNameText_TextChanged(object sender, EventArgs e)
        {
            uriSample.Text = cleanURI(uriNameText.Text) + uriExampleEnd;
        }

        // State machine execution - upkeep every 100ms
        private void timer_Tick(object sender, EventArgs e)
        {
            switch(state)
            {
                // Where the app sits most of the time
                case BinderState.Idle:
                    setProgress(0, false);
                    break;
                
                // Init or any work that needs doing before starting registry fiddling
                case BinderState.Begin:
                    setProgress(1);
                    progressLabel.Text = state.ToString();

                    // Config
                    filename = Path.GetFileName(app);

                    state = BinderState.CreateRootKey;
                    break;

                // Creating root key, separate step to help catch permissions
                case BinderState.CreateRootKey:
                    setProgress(2);

                    Registry.SetValue(rootKey, "", "URL: Alert Protocol");
                    Registry.SetValue(rootKey, "URL Protocol", "");

                    state = BinderState.CreateDefaultIcon;
                    break;
                
                // URI icon config
                case BinderState.CreateDefaultIcon:
                    setProgress(3);

                    Registry.SetValue(subkey_DefaultIcon, "", "\"" + filename + ",1\""); // Example: "alert.exe,1"

                    state = BinderState.CreateShell;
                    break;
                
                // Creates the shell commands that run the app to pass the args to it from the uri
                case BinderState.CreateShell:
                    setProgress(4);

                    Registry.SetValue(subkey_ShellOpenCommand, "", "\"" + app + "\" \"%1\"");

                    state = BinderState.CreateURLProtocol;
                    break;

                // Specifies the type of protocol for opening this app as a subkey
                case BinderState.CreateURLProtocol:
                    setProgress(5);

                    Registry.SetValue(subkey_URLProtocol, "", "");

                    state = BinderState.CreateURLProtocol;
                    break;

                case BinderState.Done:
                    setProgress(6);
                    progressLabel.Text = state.ToString();
                    progressLabel.ForeColor = Color.Green;
                    break;
            }
        }


          ///////////////////////
         // Utility Functions //
        ///////////////////////

        // Set state info
        private void setProgress(float which, bool updateLabel = true)
        {
            if (updateLabel)
            {
                progressLabel.Text = state.ToString();
            }

            progressBar.Value = (int)(which / (Enum.GetNames(typeof(BinderState)).Length - 1) * 100);
        }

        // Cleans up input strings for the URI
        private string cleanURI(String input)
        {
            return selectWhitespace.Replace(input, "").ToLowerInvariant();
        }
        
        // See if you're admin
        public bool IsAdmin()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
