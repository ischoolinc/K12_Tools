using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using Aspose.Cells;
using K12.EduAdminDataMapping.DAO;
using System.IO;

namespace K12.EduAdminDataMapping.Form
{
    public partial class NationalityMappingForm : BaseForm
    {
        BackgroundWorker _bgWorker;
        List<UDT_NationalityMapping> _NationalityMappingList = new List<UDT_NationalityMapping>();
        // 檢查資料用
        List<string> _StrList = new List<string>();
        public NationalityMappingForm()
        {
            InitializeComponent();
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            ReloadData();
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExport.Enabled = true;
            btnImport.Enabled = true;
            btnSave.Enabled = true;
            dgData.Rows.Clear();
            foreach (UDT_NationalityMapping data in _NationalityMappingList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = data;
                dgData.Rows[rowIdx].Cells[colName.Index].Value = data.Name;
                dgData.Rows[rowIdx].Cells[colEngName.Index].Value = data.Eng_Name;
            }

            // [ischoolkingdom] Vicky新增，[09-02][04] 家長國籍管理，更新國籍對照nation_mapping_new_
            // 當沒有資料載入預設
            if (_NationalityMappingList.Count == 0)
            {
                try
                {
                    Workbook wb = new Workbook();
                    wb.Open(new MemoryStream(Properties.Resources.nation_mapping_new_));
                    dgData.Rows.Clear();
                    for (int row = 1; row <= wb.Worksheets[0].Cells.MaxDataRow; row++)
                    {
                        string name = wb.Worksheets[0].Cells[row,0].StringValue;
                        if (string.IsNullOrWhiteSpace(name))
                            continue;

                        int rowIdx = dgData.Rows.Add();
                        dgData.Rows[rowIdx].Cells[colName.Index].Value = name;
                        dgData.Rows[rowIdx].Cells[colEngName.Index].Value = wb.Worksheets[0].Cells[row,1].StringValue;
                        
                    }
                    SaveData();
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("預設資料載入失敗! " + ex.Message);
                }
            }
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _NationalityMappingList = UDTTransfer.UDTNationalityMappingSelectAll();       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool SaveData()
        {
            bool pass = true;
            if (CheckData())
            {
                // 刪除舊料
                if (_NationalityMappingList.Count > 0)
                    UDTTransfer.UDTNationalityMappingDelete(_NationalityMappingList);

                // 新增資料
                List<UDT_NationalityMapping> insertList = new List<UDT_NationalityMapping>();
                foreach (DataGridViewRow drv in dgData.Rows)
                {
                    if (drv.IsNewRow)
                        continue;

                    UDT_NationalityMapping data = new UDT_NationalityMapping();
                    data.Name = drv.Cells[colName.Index].Value.ToString();
                    data.Eng_Name = drv.Cells[colEngName.Index].Value.ToString();
                    insertList.Add(data);
                }
                UDTTransfer.UDTNationalityMappingInsert(insertList);                
                ReloadData();                
            }
            else
            {
                pass = false;
                FISCA.Presentation.Controls.MsgBox.Show("畫面上資料有錯誤，請修正後再儲存!");
            }
            return pass;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(SaveData())
                FISCA.Presentation.Controls.MsgBox.Show("儲存成功");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {            
            Workbook wb = new Workbook();
            wb.Worksheets[0].Cells[0, 0].PutValue("國籍中文名稱");
            wb.Worksheets[0].Cells[0, 1].PutValue("國籍英文名稱");
            int rowIdx = 1;
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;
                wb.Worksheets[0].Cells[rowIdx, 0].PutValue(drv.Cells[colName.Index].Value.ToString());
                wb.Worksheets[0].Cells[rowIdx, 1].PutValue(drv.Cells[colEngName.Index].Value.ToString());
                rowIdx++;

            }
            Utility.CompletedXls("國籍中英文對照表", wb);
        }

        private void ReloadData()
        {
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            btnSave.Enabled = false;
            _bgWorker.RunWorkerAsync();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // 讀取 Excel 檔案
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "請選擇匯入的國籍中英文對照表";
            ofd.Filter = "Excel檔案 (*.xls)|*.xls|所有檔案 (*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 
                try
                {
                    Workbook wb = new Workbook();
                    wb.Open(ofd.FileName);
                    FISCA.Presentation.Controls.MsgBox.Show("匯入資料將取代畫面上資料，需要選儲存才會寫入資料!");
                    dgData.Rows.Clear();

                    for (int rowIdx = 1; rowIdx <= wb.Worksheets[0].Cells.MaxDataRow; rowIdx++)
                    {
                        int row = dgData.Rows.Add();
                        dgData.Rows[row].Cells[colName.Index].Value = wb.Worksheets[0].Cells[rowIdx,0].StringValue;
                        dgData.Rows[row].Cells[colEngName.Index].Value = wb.Worksheets[0].Cells[rowIdx,1].StringValue;
                    }

                }
                catch(Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("讀取匯入檔案失敗! "+ex.Message);
                }

            }
        }

        private void dgData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckData();
        }

        // 檢查資料
        private bool CheckData()
        {
            _StrList.Clear();
            bool pass = true;
            
            // 清除所有 ErrorText
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in drv.Cells)
                    cell.ErrorText = "";
            }

            // 檢查資料
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in drv.Cells)
                {
                    if (cell.ColumnIndex == colName.Index)
                    {
                        if (cell.Value == null || (cell.Value + "") == "")
                        {
                            cell.ErrorText = "中文名稱不能空白!";
                            pass = false;
                        }
                        else
                        {
                            string name = cell.Value.ToString();
                            if (_StrList.Contains(name))
                            {
                                cell.ErrorText = "中文名稱重複";
                                pass = false;
                            }
                            _StrList.Add(name);
                        }
                    }
                    else
                    {
                        if (cell.Value==null)
                            cell.Value = "";
                    }
                }             
            }
            return pass;
        }
    }
}
