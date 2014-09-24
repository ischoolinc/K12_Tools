using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation;
using K12.Presentation;
using FISCA;

namespace K12.StudentTools
{
    public class Program
    {

        [MainMethod()]
        public static void Main()
        {

            RibbonBarItem rbItem = MotherForm.RibbonBarItems["學生", "工具"];
            rbItem["加入待處理"].Enable =true;
            rbItem["加入待處理"].Click += delegate
            {
                AddTempStudent ats = new AddTempStudent();
                ats.ShowDialog();
            };

        }
    }
}
