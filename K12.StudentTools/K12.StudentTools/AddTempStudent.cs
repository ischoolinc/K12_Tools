using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Data;

namespace K12.StudentTools
{
    public partial class AddTempStudent : FISCA.Presentation.Controls.BaseForm
    {
        public AddTempStudent()
        {
            InitializeComponent();
        }

        private void AddTempStudent_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize=this.Size;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // 讀取資料
            string[] data = txtSource.Text.Split('\n');
            List<string> StudentNumber = new List<string>();
            foreach (string str in data)
            {
                if(!string.IsNullOrEmpty(str))
                    StudentNumber.Add(str.Trim());
            } 

            List<string> StudentIDList = new List<string>();

            if (StudentNumber.Count > 0)
            {
                QueryHelper qh = new QueryHelper();
                string sqlt = string.Join("','", StudentNumber.ToArray());

                string sqlStr1 = "select student.id from student where student_number in('" + sqlt + "');";
                DataTable dt1 = qh.Select(sqlStr1);
                foreach (DataRow dr in dt1.Rows)
                    StudentIDList.Add(dr[0].ToString());

                List<string> AddStudentIDList= new List<string> ();

                foreach (string id in StudentIDList)
                    if (!Presentation.NLDPanels.Student.TempSource.Contains(id))
                        AddStudentIDList.Add(id);

                if(AddStudentIDList.Count>0)
                    Presentation.NLDPanels.Student.AddToTemp(AddStudentIDList);

                FISCA.Presentation.Controls.MsgBox.Show("已加入"+AddStudentIDList.Count+"筆資料");
            }
        } 
    }
}
