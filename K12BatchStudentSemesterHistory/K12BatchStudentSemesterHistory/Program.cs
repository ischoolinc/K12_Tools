using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Permission;

namespace K12BatchStudentSemesterHistory
{
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu["產生學期對照(歷程)"].Enable = UserAcl.Current["K12BatchStudentSemesterHistory"].Executable;
            K12.Presentation.NLDPanels.Student.ListPaneContexMenu["產生學期對照(歷程)"].Click += delegate
            {
                if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
                {
                    BatchStudSemesterHistoryForm bshf = new BatchStudSemesterHistoryForm();
                    bshf.ShowDialog();
                }
            };

            // 匯入測驗
            Catalog catalog1b = RoleAclSource.Instance["學生"]["功能按鈕"];
            catalog1b.Add(new RibbonFeature("K12BatchStudentSemesterHistory", "產生學期對照(歷程)"));
        }
    }
}
