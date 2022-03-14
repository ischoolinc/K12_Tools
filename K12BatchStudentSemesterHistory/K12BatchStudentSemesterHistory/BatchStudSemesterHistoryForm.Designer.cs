﻿namespace K12BatchStudentSemesterHistory
{
    partial class BatchStudSemesterHistoryForm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnRun = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtSchoolYear = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSemester = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtGradeYear = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.chkClass = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(55, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "學年度";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(140, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(39, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "學期";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(238, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(40, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "年級";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btnRun
            // 
            this.btnRun.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRun.Location = new System.Drawing.Point(125, 77);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(62, 23);
            this.btnRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "產生";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(272, 77);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(199, 77);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(62, 23);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "刪除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.ForeColor = System.Drawing.Color.Red;
            this.labelX4.Location = new System.Drawing.Point(6, 106);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(328, 43);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "產生：學年度、學期、年級是必填欄位，依照學年度、學期比對後新增資料或覆蓋年級。";
            this.labelX4.WordWrap = true;
            // 
            // txtSchoolYear
            // 
            // 
            // 
            // 
            this.txtSchoolYear.Border.Class = "TextBoxBorder";
            this.txtSchoolYear.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSchoolYear.Location = new System.Drawing.Point(74, 12);
            this.txtSchoolYear.Name = "txtSchoolYear";
            this.txtSchoolYear.Size = new System.Drawing.Size(68, 25);
            this.txtSchoolYear.TabIndex = 10;
            // 
            // txtSemester
            // 
            // 
            // 
            // 
            this.txtSemester.Border.Class = "TextBoxBorder";
            this.txtSemester.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSemester.Location = new System.Drawing.Point(182, 12);
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(55, 25);
            this.txtSemester.TabIndex = 11;
            // 
            // txtGradeYear
            // 
            // 
            // 
            // 
            this.txtGradeYear.Border.Class = "TextBoxBorder";
            this.txtGradeYear.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGradeYear.Location = new System.Drawing.Point(278, 12);
            this.txtGradeYear.Name = "txtGradeYear";
            this.txtGradeYear.Size = new System.Drawing.Size(55, 25);
            this.txtGradeYear.TabIndex = 12;
            // 
            // chkClass
            // 
            this.chkClass.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkClass.BackgroundStyle.Class = "";
            this.chkClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkClass.Location = new System.Drawing.Point(21, 44);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(313, 23);
            this.chkClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkClass.TabIndex = 13;
            this.chkClass.Text = "帶入學生當前班級資訊";
            // 
            // labelX5
            // 
            this.labelX5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Red;
            this.labelX5.Location = new System.Drawing.Point(6, 155);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(328, 41);
            this.labelX5.TabIndex = 14;
            this.labelX5.Text = "刪除：學年度、學期是必填欄位，年級非必填，依照學年度、學期比對後刪除資料。";
            this.labelX5.WordWrap = true;
            // 
            // labelX6
            // 
            this.labelX6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.ForeColor = System.Drawing.Color.Red;
            this.labelX6.Location = new System.Drawing.Point(6, 202);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(328, 41);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "以當前學生班級資訊設定寫入資訊，如需變更，請至資料項目修改。";
            this.labelX6.WordWrap = true;
            // 
            // BatchStudSemesterHistoryForm
            // 
            this.ClientSize = new System.Drawing.Size(343, 257);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.txtGradeYear);
            this.Controls.Add(this.txtSemester);
            this.Controls.Add(this.txtSchoolYear);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "BatchStudSemesterHistoryForm";
            this.Text = "產生學期對照(歷程)";
            this.Load += new System.EventHandler(this.BatchStudSemesterHistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnRun;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSchoolYear;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSemester;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGradeYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkClass;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX6;
    }
}