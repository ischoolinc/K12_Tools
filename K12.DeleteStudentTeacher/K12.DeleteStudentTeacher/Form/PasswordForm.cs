using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Authentication;

namespace K12.DeleteStudentTeacher.Form
{
    public partial class PasswordForm :BaseForm
    {
        /// <summary>
        /// 資料類型
        /// </summary>
        public enum DataType { Student, Teacher }

        /// <summary>
        /// 資料ID
        /// </summary>
        private List<string> _dataIDList;

        DataType _dataType;

        public PasswordForm(DataType dataType,List<string> DataIDList)
        {
            InitializeComponent();
            _dataType = dataType;
            _dataIDList = DataIDList;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            lblUserName.Text = DSAServices.UserAccount;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MsgBox.Show("請輸入密碼!");
                return;
            }
           
            bool pass=false ;
            try
            {
                pass = DSAServices.ConfirmPassword(txtPassword.Text, null);
            }
            catch (Exception ex)
            {
                MsgBox.Show(FISCA.ErrorReport.Generate(ex));
                return;            
            }

            if (pass)
            {
                if (_dataType == DataType.Student)
                {
                    if (MsgBox.Show(_dataIDList.Count+"位學生在系統內將永久刪除無法回復，確定要刪除?", "永久刪除學生", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // 取得 Log 需要資料
                        DAO.DataManager.SetStudentLogData(_dataIDList);

                        // 刪除學生
                        DAO.DataManager.DelStudentByIDList(_dataIDList);

                        // 儲存 log
                        DAO.DataManager.SaveStudentLogData();

                        K12.Presentation.NLDPanels.Student.RefillListPane();                        
                    }
                    else
                        return;
                }

                if (_dataType == DataType.Teacher)
                {
                    if (MsgBox.Show(_dataIDList.Count + "位教師在系統內將永久刪除無法回復，確定要刪除?", "永久刪除教師", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // 取得 Log 需要資料
                        DAO.DataManager.SetTeacherLogData(_dataIDList);

                        // 刪除教師
                        DAO.DataManager.DelTeacherByIDList(_dataIDList);

                        // 儲存 log
                        DAO.DataManager.SaveTeacherLogData();
                    }
                    else
                        return;                
                }
            }
            else
            {
                MsgBox.Show("密碼錯誤");
                return;            
            }

            this.Close();
        }
    }
}
