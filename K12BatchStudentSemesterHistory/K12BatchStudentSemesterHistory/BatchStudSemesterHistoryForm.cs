using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Data;
using K12.Data;

namespace K12BatchStudentSemesterHistory
{
    public partial class BatchStudSemesterHistoryForm : FISCA.Presentation.Controls.BaseForm
    {
        List<SemesterHistoryRecord> _SemesterHistoryRecordList;
        //List<StudentRecord> _StudRecList;
        BackgroundWorker _bkWorker;
        bool _isDelRec = false;
        int _SelSchoolYear, _SelSemester, _SelGradeYear;
        List<SemesterHistoryRecord> _DelRecList;
        List<SemesterHistoryRecord> _NewRecList;
        bool _noError = true;

        /// <summary>
        /// 帶入學生當前資訊
        /// </summary>
        bool _IsExtData = false;
        /// <summary>
        /// 學生資訊
        /// </summary>
        List<StudentInfo> _StudentInfo;

        public BatchStudSemesterHistoryForm()
        {
            InitializeComponent();
            this.MaximumSize = this.MinimumSize = this.Size;
            _SemesterHistoryRecordList = new List<SemesterHistoryRecord>();
            //_StudRecList = new List<StudentRecord>();
            _bkWorker = new BackgroundWorker();
            _DelRecList = new List<SemesterHistoryRecord>();
            _NewRecList = new List<SemesterHistoryRecord>();
            _bkWorker.DoWork += new DoWorkEventHandler(_bkWorker_DoWork);
            _bkWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bkWorker_RunWorkerCompleted);

        }

        void _bkWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _DelRecList.Clear();
            _NewRecList.Clear();

            // 刪除
            if (_isDelRec)
            {
                foreach (SemesterHistoryRecord shRec in _SemesterHistoryRecordList)
                {
                    SemesterHistoryItem shiRec = null;
                    foreach (SemesterHistoryItem shi in shRec.SemesterHistoryItems)
                    {
                        if (shi.SchoolYear == _SelSchoolYear && shi.Semester == _SelSemester)
                            shiRec = shi;
                    }
                    if (shiRec != null)
                    {
                        shRec.SemesterHistoryItems.Remove(shiRec);
                        _DelRecList.Add(shRec);
                    }
                }
                if (_DelRecList.Count > 0)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("請問是否刪除" + _SelSchoolYear + "學年度 第" + _SelSemester + "學期,共" + _DelRecList.Count + "筆資料?", "刪除學期對照", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SemesterHistory.Update(_DelRecList);
                        FISCA.Presentation.Controls.MsgBox.Show(_DelRecList.Count + "筆資料刪除完成.");
                    }
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("沒有刪除的資料.");
                }

                btnDel.Enabled = true;
            }
            else
            {
                // 新增或修改
                int insertCount = 0, updateCount = 0;
                foreach (SemesterHistoryRecord shRec in _SemesterHistoryRecordList)
                {
                    bool hasData = false;
                    foreach (SemesterHistoryItem shi in shRec.SemesterHistoryItems)
                    {
                        if (shi.SchoolYear == _SelSchoolYear && shi.Semester == _SelSemester)
                        {
                            if (_IsExtData)
                            {
                                foreach (StudentInfo studentInfo in _StudentInfo)
                                {
                                    if (shi.RefStudentID == studentInfo.StudentID)
                                    {
                                        shi.StudentNumber = studentInfo.StudentNumber;
                                        shi.DeptName = studentInfo.DeptName;
                                        shi.ClassName = studentInfo.ClassName;
                                        if (studentInfo.SeatNo.HasValue)
                                            shi.SeatNo = studentInfo.SeatNo;
                                        else
                                            shi.SeatNo = null;
                                        shi.Teacher = studentInfo.TeacherName;
                                        shi.GDCCode = studentInfo.GDCCode;
                                        shi.ClassID = studentInfo.ClassID;
                                    }
                                }
                            }
                            shi.GradeYear = _SelGradeYear;
                            hasData = true;
                            updateCount++;
                        }
                    }

                    if (hasData == false)
                    {
                        SemesterHistoryItem shiNew = new SemesterHistoryItem();
                        if (_IsExtData)
                        {
                            foreach (StudentInfo studentInfo in _StudentInfo)
                            {
                                if (shRec.RefStudentID == studentInfo.StudentID)
                                {
                                    shiNew.StudentNumber = studentInfo.StudentNumber;
                                    shiNew.DeptName = studentInfo.DeptName;
                                    shiNew.ClassName = studentInfo.ClassName;
                                    if (studentInfo.SeatNo.HasValue)
                                        shiNew.SeatNo = studentInfo.SeatNo;
                                    else
                                        shiNew.SeatNo = null;
                                    shiNew.Teacher = studentInfo.TeacherName;
                                    shiNew.GDCCode = studentInfo.GDCCode;
                                    shiNew.ClassID = studentInfo.ClassID;
                                }
                            }

                        }
                        shiNew.SchoolYear = _SelSchoolYear;
                        shiNew.Semester = _SelSemester;
                        shiNew.GradeYear = _SelGradeYear;
                        shRec.SemesterHistoryItems.Add(shiNew);
                        insertCount++;
                    }
                }

                if (updateCount > 0)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("已有" + updateCount + "筆資料，請問是否覆蓋?", "覆蓋學期對照", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SemesterHistory.Update(_SemesterHistoryRecordList);
                        FISCA.Presentation.Controls.MsgBox.Show("已新增" + insertCount + "筆資料，已覆蓋" + updateCount + "筆資料.");
                    }
                }
                else
                {
                    if (insertCount > 0)
                    {
                        SemesterHistory.Update(_SemesterHistoryRecordList);
                        FISCA.Presentation.Controls.MsgBox.Show("已新增" + insertCount + "筆資料.");
                    }
                }

                btnRun.Enabled = true;
            }

        }

        void _bkWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //// 學生紀錄
            //_StudRecList = Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource);
            // 學期對照
            _SemesterHistoryRecordList = SemesterHistory.SelectByStudentIDs(K12.Presentation.NLDPanels.Student.SelectedSource);

            _IsExtData = chkClass.Checked;
            if (_IsExtData)
                _StudentInfo = GetStudentInfo();
        }

        /// <summary>
        /// 取得學生資訊
        /// </summary>
        /// <returns></returns>
        private List<StudentInfo> GetStudentInfo()
        {
            List<StudentInfo> studentInfoList = new List<StudentInfo>();
            try
            {
                QueryHelper qh = new QueryHelper();

                string qry = @"
WITH student_data AS (
    SELECT
		student.id AS student_id
		, student_number
		, seat_no
		, teacher_name
		, class.id AS class_id
		, class_name 
		, COALESCE(student.ref_dept_id,class.ref_dept_id)  AS dept_id
		, COALESCE(student.gdc_code,class.gdc_code) AS gdc_code
    FROM student 
    LEFT JOIN class ON student.ref_class_id = class.id
	LEFT JOIN teacher ON class.ref_teacher_id = teacher.id
    WHERE student.id IN(" + string.Join(",", K12.Presentation.NLDPanels.Student.SelectedSource.ToArray()) + ")"
+ @")
SELECT  
	student_id
	, student_number
	, seat_no
	, teacher_name
	, class_id
	, class_name
	, gdc_code
	, name AS dept_name
	FROM student_data 
	LEFT JOIN dept ON student_data.dept_id = dept.id 
";

                DataTable dt = qh.Select(qry);

                foreach (DataRow dr in dt.Rows)
                {
                    StudentInfo studentInfo = new StudentInfo();

                    studentInfo.StudentID = dr["student_id"].ToString();
                    int seatNo;
                    if (int.TryParse(dr["seat_no"].ToString(), out seatNo))
                        studentInfo.SeatNo = seatNo;
                    studentInfo.StudentNumber = dr["student_number"].ToString();
                    studentInfo.ClassID = dr["class_id"].ToString();
                    studentInfo.ClassName = dr["class_name"].ToString();
                    studentInfo.TeacherName = dr["teacher_name"].ToString();
                    studentInfo.DeptName = dr["dept_name"].ToString();
                    studentInfo.GDCCode = dr["gdc_code"].ToString();

                    studentInfoList.Add(studentInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return studentInfoList;
        }

        private void SetSelData()
        {
            _noError = true;
            _SelSchoolYear = _SelSemester = _SelGradeYear = 0;
            int sy, ss, gr;

            if (int.TryParse(txtSchoolYear.Text, out sy))
                _SelSchoolYear = sy;
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("學年度必填，必須為數字。");
                _noError = false;
            }

            if (int.TryParse(txtSemester.Text, out ss))
            {
                _SelSemester = ss;
                if (ss < 1 || ss > 2)
                    if (FISCA.Presentation.Controls.MsgBox.Show("學期輸入數字不在1~2之間，請問是否繼續?", "學期問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                        _noError = false;

            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("學期必填，必須為數字");
                _noError = false;
            }

            if (_isDelRec == false)
            {
                if (int.TryParse(txtGradeYear.Text, out gr))
                {
                    _SelGradeYear = gr;
                    if (gr < 1 || gr > 12)
                        if (FISCA.Presentation.Controls.MsgBox.Show("年級輸入數字不在1~12之間，請問是否繼續?", "年級問題", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                            _noError = false;

                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("年級必填，必須為數字");
                    _noError = false;
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BatchStudSemesterHistoryForm_Load(object sender, EventArgs e)
        {
            // 載入預設值
            txtSchoolYear.Text = School.DefaultSchoolYear;
            txtSemester.Text = School.DefaultSemester;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            _isDelRec = false;
            SetSelData();
            if (_noError)
            {
                btnRun.Enabled = false;
                _bkWorker.RunWorkerAsync();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            _isDelRec = true;
            SetSelData();
            if (_noError)
            {
                btnDel.Enabled = false;
                _bkWorker.RunWorkerAsync();
            }
        }

    }
}
