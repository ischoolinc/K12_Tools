using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using System.IO;
using Aspose.Cells;

namespace K12.EduAdminDataMapping.DAO
{
    class UDTTransfer
    {
        /// <summary>
        /// 取得國籍中英文對照UDT
        /// </summary>
        /// <returns></returns>
        public static List<UDT_NationalityMapping> UDTNationalityMappingSelectAll()
        {
            List<UDT_NationalityMapping> retVal = new List<UDT_NationalityMapping>();
            AccessHelper accessHelper = new AccessHelper();
            retVal = accessHelper.Select<UDT_NationalityMapping>();
            return retVal;
        }

        /// <summary>
        /// 啟動國籍中英文對照UDT
        /// </summary>
        /// <returns></returns>
        public static void UDTNationalityMappingLoad()
        {            
            AccessHelper accessHelper = new AccessHelper();
            List<UDT_NationalityMapping> dataList= accessHelper.Select<UDT_NationalityMapping>();
            if (dataList.Count == 0)
            {
                try
                {
                    Workbook wb = new Workbook();
                    wb.Open(new MemoryStream(Properties.Resources.nation_mapping));
                    List<UDT_NationalityMapping> insertDataList = new List<UDT_NationalityMapping>();
                    for (int row = 1; row <= wb.Worksheets[0].Cells.MaxDataRow; row++)
                    {
                        string name = wb.Worksheets[0].Cells[row, 0].StringValue;
                        if (string.IsNullOrWhiteSpace(name))
                            continue;

                        UDT_NationalityMapping data = new UDT_NationalityMapping();
                        data.Name = name;
                        data.Eng_Name = wb.Worksheets[0].Cells[row, 1].StringValue;
                        insertDataList.Add(data);
                    }
                    UDTTransfer.UDTNationalityMappingInsert(insertDataList);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("預設資料載入失敗! " + ex.Message);
                }
            }
        }

        /// <summary>
        /// 新增國籍中英文對照UDT
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTNationalityMappingInsert(List<UDT_NationalityMapping> dataList)
        {
            AccessHelper accessHelper = new AccessHelper();
            accessHelper.InsertValues(dataList);
        }

        /// <summary>
        /// 更新國籍中英文對照UDT
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTNationalityMappingUpdate(List<UDT_NationalityMapping> dataList)
        {
            AccessHelper accessHelper = new AccessHelper();
            accessHelper.UpdateValues(dataList);
        }

        /// <summary>
        /// 刪除國籍中英文對照UDT
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTNationalityMappingDelete(List<UDT_NationalityMapping> dataList)
        {
            foreach (UDT_NationalityMapping data in dataList)
                data.Deleted = true;

            AccessHelper accessHelper = new AccessHelper();
            accessHelper.DeletedValues(dataList);
        }
    }
}
