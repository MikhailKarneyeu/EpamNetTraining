using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Exam: IComparable
    {
        public int ExamID { get; set; }
        public int SessionID { get; set; }
        public int SubjectID { get; set; }
        public int TeacherID { get; set; }
        public DateTime Date { get; set; }
        public Exam()
        {
        }
        public Exam(int examID, int sessionID, int subjectID, int teacherID, DateTime date)
        {
            ExamID = examID;
            SessionID = sessionID;
            SubjectID = subjectID;
            TeacherID = teacherID;
            Date = date;
        }

        public int CompareTo(object obj)
        {
            if (obj is Exam e)
                return this.ExamID.CompareTo(e.ExamID);
            else
                throw new Exception("Invalid type object.");
        }

        public override bool Equals(object obj)
        {
            if (typeof(Exam) !=obj.GetType())
                return false;
            if (ToString().Equals(obj.ToString()))
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ExamID};{SessionID};{SubjectID};{Date}";
        }
    }
}
