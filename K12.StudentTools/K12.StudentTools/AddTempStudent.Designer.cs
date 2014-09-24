namespace K12.StudentTools
{
    partial class AddTempStudent
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
            this.txtSource = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnRun = new DevComponents.DotNetBar.ButtonX();
            this.Exit = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            // 
            // 
            // 
            this.txtSource.Border.Class = "TextBoxBorder";
            this.txtSource.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(213, 202);
            this.txtSource.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRun.Location = new System.Drawing.Point(65, 220);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "加入待處理";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // Exit
            // 
            this.Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Exit.Location = new System.Drawing.Point(151, 220);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Exit.TabIndex = 2;
            this.Exit.Text = "離開";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // AddTempStudent
            // 
            this.ClientSize = new System.Drawing.Size(239, 252);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtSource);
            this.Name = "AddTempStudent";
            this.Text = "依學號加入待處理學生";
            this.Load += new System.EventHandler(this.AddTempStudent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSource;
        private DevComponents.DotNetBar.ButtonX btnRun;
        private DevComponents.DotNetBar.ButtonX Exit;
    }
}