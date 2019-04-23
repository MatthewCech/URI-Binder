namespace URI_Binder
{
    partial class URIBinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selectAppDialog = new System.Windows.Forms.OpenFileDialog();
            this.appSelectButon = new System.Windows.Forms.Button();
            this.appSelectText = new System.Windows.Forms.TextBox();
            this.uriNameText = new System.Windows.Forms.TextBox();
            this.appSelectLabel = new System.Windows.Forms.Label();
            this.uriNameLabel = new System.Windows.Forms.Label();
            this.uriInfo = new System.Windows.Forms.Label();
            this.appInfo = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // selectAppDialog
            // 
            this.selectAppDialog.DefaultExt = "exe";
            // 
            // appSelectButon
            // 
            this.appSelectButon.Location = new System.Drawing.Point(436, 36);
            this.appSelectButon.Name = "appSelectButon";
            this.appSelectButon.Size = new System.Drawing.Size(75, 23);
            this.appSelectButon.TabIndex = 1;
            this.appSelectButon.Text = "Browse";
            this.appSelectButon.UseVisualStyleBackColor = true;
            this.appSelectButon.Click += new System.EventHandler(this.appSelectButon_Click);
            // 
            // appSelectText
            // 
            this.appSelectText.Location = new System.Drawing.Point(9, 38);
            this.appSelectText.Name = "appSelectText";
            this.appSelectText.Size = new System.Drawing.Size(419, 20);
            this.appSelectText.TabIndex = 3;
            // 
            // uriNameText
            // 
            this.uriNameText.Location = new System.Drawing.Point(9, 102);
            this.uriNameText.Name = "uriNameText";
            this.uriNameText.Size = new System.Drawing.Size(100, 20);
            this.uriNameText.TabIndex = 4;
            // 
            // appSelectLabel
            // 
            this.appSelectLabel.AutoSize = true;
            this.appSelectLabel.Location = new System.Drawing.Point(6, 9);
            this.appSelectLabel.Name = "appSelectLabel";
            this.appSelectLabel.Size = new System.Drawing.Size(106, 13);
            this.appSelectLabel.TabIndex = 5;
            this.appSelectLabel.Text = "Application Selection";
            // 
            // uriNameLabel
            // 
            this.uriNameLabel.AutoSize = true;
            this.uriNameLabel.Location = new System.Drawing.Point(6, 73);
            this.uriNameLabel.Name = "uriNameLabel";
            this.uriNameLabel.Size = new System.Drawing.Size(57, 13);
            this.uriNameLabel.TabIndex = 6;
            this.uriNameLabel.Text = "URI Name";
            // 
            // uriInfo
            // 
            this.uriInfo.AutoSize = true;
            this.uriInfo.ForeColor = System.Drawing.Color.Gray;
            this.uriInfo.Location = new System.Drawing.Point(6, 86);
            this.uriInfo.Name = "uriInfo";
            this.uriInfo.Size = new System.Drawing.Size(355, 13);
            this.uriInfo.TabIndex = 7;
            this.uriInfo.Text = "This is the text on the left of an app link. \'example\' would be \'example://...\'";
            // 
            // appInfo
            // 
            this.appInfo.AutoSize = true;
            this.appInfo.ForeColor = System.Drawing.Color.Gray;
            this.appInfo.Location = new System.Drawing.Point(6, 22);
            this.appInfo.Name = "appInfo";
            this.appInfo.Size = new System.Drawing.Size(391, 13);
            this.appInfo.TabIndex = 8;
            this.appInfo.Text = "This is the path to the application you want to launch when a URI is navigated to" +
    ".";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(436, 158);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 158);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(419, 23);
            this.progressBar.TabIndex = 10;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.Gray;
            this.progressLabel.Location = new System.Drawing.Point(12, 183);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(18, 12);
            this.progressLabel.TabIndex = 11;
            this.progressLabel.Text = ". . .";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // URIBinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 205);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.appInfo);
            this.Controls.Add(this.uriInfo);
            this.Controls.Add(this.uriNameLabel);
            this.Controls.Add(this.appSelectLabel);
            this.Controls.Add(this.uriNameText);
            this.Controls.Add(this.appSelectText);
            this.Controls.Add(this.appSelectButon);
            this.Name = "URIBinder";
            this.Text = "URI Binder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog selectAppDialog;
        private System.Windows.Forms.Button appSelectButon;
        private System.Windows.Forms.TextBox appSelectText;
        private System.Windows.Forms.TextBox uriNameText;
        private System.Windows.Forms.Label appSelectLabel;
        private System.Windows.Forms.Label uriNameLabel;
        private System.Windows.Forms.Label uriInfo;
        private System.Windows.Forms.Label appInfo;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Timer timer;
    }
}

