using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Permission;
using FISCA.Presentation;

namespace K12.EduAdminDataMapping
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {
            // 載入 UDT
            DAO.UDTTransfer.UDTNationalityMappingLoad();
            
            // 國籍中英文對照表
            RibbonBarItem item01 = MotherForm.RibbonBarItems["教務作業","基本設定"];
            item01["對照/代碼"]["國籍中英文對照表"].Enable = UserAcl.Current["K12.EduAdminDataMapping.NationalityMappingForm"].Executable;            
            item01["對照/代碼"]["國籍中英文對照表"].Click+=delegate
            {
                Form.NationalityMappingForm nmf = new Form.NationalityMappingForm();
                nmf.ShowDialog();
            };

            // 國籍中英文對照表
            Catalog catalog01 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            catalog01.Add(new RibbonFeature("K12.EduAdminDataMapping.NationalityMappingForm", "國籍中英文對照表"));
        }
    }
}
