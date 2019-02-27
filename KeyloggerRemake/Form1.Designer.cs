namespace KeyloggerRemake
{
    partial class frmMain
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
            this.txtCurrentWindow = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tmrCheckKeys = new System.Windows.Forms.Timer(this.components);
            this.tmrGetWindow = new System.Windows.Forms.Timer(this.components);
            this.tmrParseSettings = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtCurrentWindow
            // 
            this.txtCurrentWindow.BackColor = System.Drawing.Color.Black;
            this.txtCurrentWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentWindow.Enabled = false;
            this.txtCurrentWindow.ForeColor = System.Drawing.Color.White;
            this.txtCurrentWindow.Location = new System.Drawing.Point(12, 335);
            this.txtCurrentWindow.Name = "txtCurrentWindow";
            this.txtCurrentWindow.ReadOnly = true;
            this.txtCurrentWindow.Size = new System.Drawing.Size(105, 20);
            this.txtCurrentWindow.TabIndex = 56;
            this.txtCurrentWindow.Text = "Active Window";
            this.txtCurrentWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentWindow.TextChanged += new System.EventHandler(this.txtCurrentWindow_TextChanged);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Enabled = false;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Green;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(680, 317);
            this.txtLog.TabIndex = 40;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(123, 335);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(456, 23);
            this.Label1.TabIndex = 41;
            this.Label1.Text = "#2019";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrCheckKeys
            // 
            this.tmrCheckKeys.Interval = 10;
            this.tmrCheckKeys.Tick += new System.EventHandler(this.tmrCheckKeys_Tick);
            // 
            // tmrGetWindow
            // 
            this.tmrGetWindow.Tick += new System.EventHandler(this.tmrGetWindow_Tick);
            // 
            // tmrParseSettings
            // 
            this.tmrParseSettings.Tick += new System.EventHandler(this.tmrParseSettings_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(704, 363);
            this.Controls.Add(this.txtCurrentWindow);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REMAKE";
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCurrentWindow;
        internal System.Windows.Forms.TextBox txtLog;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Timer tmrCheckKeys;
        private System.Windows.Forms.Timer tmrGetWindow;
        private System.Windows.Forms.Timer tmrParseSettings;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

