using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using FISCA.LogAgent;
using FISCA.Presentation.Controls;

namespace K12.DeleteStudentTeacher.DAO
{
    /// <summary>
    /// 資料交換使用
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// log 學生資料使用
        /// </summary>
        static Dictionary<string, string> _studLogData = new Dictionary<string, string>();
        /// <summary>
        /// log 教師資料使用
        /// </summary>
        static Dictionary<string, string> _teacherLogData = new Dictionary<string, string>();

        /// <summary>
        /// 判斷傳入StudentID是否都是刪除狀態
        /// </summary>
        /// <param name="StudentIDList"></param>
        /// <returns></returns>
        public static bool isAllDelStatusStudent(List<string> StudentIDList)
        {
            bool retVal = true;

            if (StudentIDList.Count == 0)
                retVal = false;
            else
            {
                foreach (StudentRecord studRec in Student.SelectByIDs(StudentIDList))
                    if (studRec.Status != StudentRecord.StudentStatus.刪除)
                    {
                        retVal = false;
                        break;
                    }
            }
            return retVal;
        }

        /// <summary>
        /// 判斷傳入TeacherID是否都是刪除狀態
        /// </summary>
        /// <param name="TeacherIDList"></param>
        /// <returns></returns>
        public static bool isAllDelStatusTeacher(List<string> TeacherIDList)
        {
            bool retVal = true;

            if (TeacherIDList.Count == 0)
                retVal = false;
            else
            { 
                foreach(TeacherRecord trRec in Teacher.SelectByIDs(TeacherIDList))
                    if (trRec.Status != TeacherRecord.TeacherStatus.刪除)
                    {
                        retVal = false;
                        break;
                    }
            }
            return retVal;
        }

        /// <summary>
        /// 收集與設定學生Log
        /// </summary>
        public static void SetStudentLogData(List<string> StudentIDList)
        {
            _studLogData.Clear();

            List<StudentRecord> studRecList = Student.SelectByIDs(StudentIDList);

            List<string> logdata = new List<string> ();
            foreach (StudentRecord studRec in studRecList)
            {
                logdata.Clear();
                logdata.Add("學生系統編號："+studRec.ID);
                logdata.Add("學號："+studRec.StudentNumber);
                if(studRec.Class !=null)
                    logdata.Add("班級："+studRec.Class.Name);
                else
                    logdata.Add ("班級：");
                if(studRec.SeatNo.HasValue)
                    logdata.Add("座號："+studRec.SeatNo.Value);
                else
                    logdata.Add("座號：");
                
                logdata.Add("姓名："+studRec.Name);
                logdata.Add("身分證號："+studRec.IDNumber);
                logdata.Add("登入帳號："+studRec.SALoginName);

                _studLogData.Add(studRec.ID,string.Join(",",logdata.ToArray()));
            }        
        }

        /// <summary>
        /// 儲存學生Log
        /// </summary>
        public static void SaveStudentLogData()
        {
            StringBuilder sbSud = new StringBuilder();
            if (_studLogData.Count>0)
                foreach (string str in _studLogData.Values)
                    sbSud.AppendLine(str);

            if (sbSud.Length > 0)
            {
                sbSud.AppendLine("總共永久刪除學生"+_studLogData.Values.Count+"筆");
                ApplicationLog.Log("核心模組.永久刪除學生",sbSud.ToString());            
            }
        }

        /// <summary>
        /// 收集與設定教師Log
        /// </summary>
        public static void SetTeacherLogData(List<string> TeacherIDList)
        {
            _teacherLogData.Clear();
            List<TeacherRecord> teacherRecList = Teacher.SelectByIDs(TeacherIDList);
            List<string> logdata = new List<string>();

            foreach (TeacherRecord trRec in teacherRecList)
            {
                logdata.Clear();
                logdata.Add("教師系統編號：" + trRec.ID);
                logdata.Add("姓名：" + trRec.Name);
                logdata.Add("暱稱：" + trRec.Nickname);
                logdata.Add("身分證號：" + trRec.IDNumber);
                logdata.Add("登入帳號：" + trRec.TALoginName);
                _teacherLogData.Add(trRec.ID,string.Join(",",logdata.ToArray ()));
            }
        }

        /// <summary>
        /// 儲存教師Log
        /// </summary>
        public static void SaveTeacherLogData()
        {
            StringBuilder sbTeracher = new StringBuilder();
            if (_teacherLogData.Count > 0)
                foreach (string str in _teacherLogData.Values)
                    sbTeracher.AppendLine(str);
            if (sbTeracher.Length > 0)
            {
                sbTeracher.AppendLine("總共永久刪除教師" + _teacherLogData.Values.Count + "筆");
                ApplicationLog.Log("核心模組.永久刪除教師",sbTeracher.ToString());
            }
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="IDList"></param>
        internal static void DelStudentByIDList(List<string> IDList)
        {
            if (IDList.Count > 0)
            {
                try
                {
                    Student.Delete(IDList);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 刪除教師資料
        /// </summary>
        /// <param name="IDLIst"></param>
        internal static void DelTeacherByIDList(List<string> IDLIst)
        {
            if (IDLIst.Count > 0)
            {
                try
                {
                    // 檢查刪除教師是否有帶班
                    List<ClassRecord> upClassRecList = new List<ClassRecord>();
                    List<ClassRecord> ClassRecs = Class.SelectAll();
                    foreach (ClassRecord cr in ClassRecs)
                    {
                        if (IDLIst.Contains(cr.RefTeacherID))
                        {
                            cr.RefTeacherID = "";
                            upClassRecList.Add(cr);
                        }
                    }

                    // 清除帶班
                    if (upClassRecList.Count > 0)
                        Class.Update(upClassRecList);

                    Teacher.Delete(IDLIst);
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);                
                }
                 

            }
        }
    }
}
