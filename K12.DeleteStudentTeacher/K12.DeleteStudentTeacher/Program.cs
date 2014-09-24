using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Permission;
using FISCA.LogAgent;

namespace K12.DeleteStudentTeacher
{
    /// <summary>
    /// 永久刪除學生與教師功能
    /// </summary>
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            string studentName = "永久刪除學生";
            string DelStudentPhotoName = "清除學生照片";
            string studentCode = "K12DeleteStudentData";
            string DelStudentPhotoCode = "K12DeleteStudentPhoto";
            string teacherName = "永久刪除教師";
            string teacherCode = "K12DeleteTeacher";

            // 學生
            K12.Presentation.NLDPanels.Student.SelectedSourceChanged+=delegate            
            {
                K12.Presentation.NLDPanels.Student.ListPaneContexMenu[studentName].Enable = false;
                // 有選擇學生且學生都是刪除狀態
                if (UserAcl.Current[studentCode].Executable && K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0 && DAO.DataManager.isAllDelStatusStudent(K12.Presentation.NLDPanels.Student.SelectedSource))
                    K12.Presentation.NLDPanels.Student.ListPaneContexMenu[studentName].Enable = true;            
            };

            K12.Presentation.NLDPanels.Student.ListPaneContexMenu[studentName].Click += delegate
            {
                Form.PasswordForm studForm = new Form.PasswordForm(Form.PasswordForm.DataType.Student, K12.Presentation.NLDPanels.Student.SelectedSource);
                studForm.Show();                             
            };

            // 清除學生照片
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu[DelStudentPhotoName].Enable = UserAcl.Current[DelStudentPhotoCode].Executable;
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu[DelStudentPhotoName]["入學照片"].Click += delegate
            {
                if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("請問是否清除入學照片?", "清除入學照片", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("== 清除學生入學照片 ==");

                        List<K12.Data.StudentRecord> studRecList = K12.Data.Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource);

                        foreach (K12.Data.StudentRecord studRec in studRecList)
                        {
                            sb.AppendLine("學號：" + studRec.StudentNumber + ", 姓名：" + studRec.Name);
                            K12.Data.Photo.UpdateFreshmanPhoto("", studRec.ID);
                        }
                        ApplicationLog.Log("核心模組.清除學生入學照片", sb.ToString());
                        FISCA.Presentation.Controls.MsgBox.Show("清除完成");                        
                    }
                }
            };

            K12.Presentation.NLDPanels.Student.ListPaneContexMenu[DelStudentPhotoName].Enable = UserAcl.Current[DelStudentPhotoCode].Executable;
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu[DelStudentPhotoName]["畢業照片"].Click += delegate
            {
                if (FISCA.Presentation.Controls.MsgBox.Show("請問是否清除畢業照片?", "清除畢業照片", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("== 清除學生畢業照片 ==");

                    List<K12.Data.StudentRecord> studRecList = K12.Data.Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource);

                    foreach (K12.Data.StudentRecord studRec in studRecList)
                    {
                        sb.AppendLine("學號：" + studRec.StudentNumber + ", 姓名：" + studRec.Name);
                        K12.Data.Photo.UpdateGraduatePhoto("", studRec.ID);
                    }
                    ApplicationLog.Log("核心模組.清除學生畢業照片", sb.ToString());
                    FISCA.Presentation.Controls.MsgBox.Show("清除完成");                    
                }

            };


            Catalog catalogStudent = RoleAclSource.Instance["學生"]["功能按鈕"];
            catalogStudent.Add(new RibbonFeature(studentCode, studentName));
            catalogStudent.Add(new RibbonFeature(DelStudentPhotoCode,DelStudentPhotoName ));

            // 教師
            K12.Presentation.NLDPanels.Teacher.SelectedSourceChanged+=delegate
            {
                K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu[teacherName].Enable = false;

                // 有選教師且教師狀態都是刪除
                if (UserAcl.Current[teacherCode].Executable && K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0 && DAO.DataManager.isAllDelStatusTeacher(K12.Presentation.NLDPanels.Teacher.SelectedSource))
                    K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu[teacherName].Enable = true;
            
            };
            K12.Presentation.NLDPanels.Teacher.ListPaneContexMenu[teacherName].Click += delegate
            {                    
                Form.PasswordForm teacherForm = new Form.PasswordForm(Form.PasswordForm.DataType.Teacher, K12.Presentation.NLDPanels.Teacher.SelectedSource);
                teacherForm.Show();                              
            };
                        
            Catalog catalogTeacher = RoleAclSource.Instance["教師"]["功能按鈕"];
            catalogTeacher.Add(new RibbonFeature(teacherCode,teacherName));
        
        }


        
    }
}
