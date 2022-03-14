using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12BatchStudentSemesterHistory
{
    /// <summary>
    /// 裝學生資訊
    /// </summary>
    public class StudentInfo
    {
        /// <summary>
        /// 學生
        /// </summary>
        public string StudentID { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string StudentNumber { get; set; }

        /// <summary>
        /// 座號
        /// </summary>
        public int? SeatNo { get; set; }

        /// <summary>
        /// 班級系統編號
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 科別名稱
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 班導師名稱
        /// </summary>

        public string TeacherName { get; set; }

        /// <summary>
        /// 群科班代碼
        /// </summary>
        public string GDCCode { get; set; }
    }
}
