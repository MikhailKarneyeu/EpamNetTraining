using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class ExamResult: IComparable
    {
        public int ExamResultID { get; set; }
        public int ExamID { get; set; }
        public int StudentID { get; set; }
        public string Grade { get; set; }
        public ExamResult()
        {
        }
        public ExamResult(int examResultID, int examID, int studentID, string grade)
        {
            ExamResultID = examResultID;
            ExamID = examID;
            StudentID = studentID;
            Grade = grade;
        }
        public int CompareTo(object obj)
        {
            if (obj is ExamResult e)
                return this.ExamID.CompareTo(e.ExamID);
            else
                throw new Exception("Invalid type object.");
        }
        public override bool Equals(object obj)
        {
            if (typeof(ExamResult) != obj.GetType())
                return false;
            if (ToString() == obj.ToString())
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ExamResultID};{ExamID};{StudentID};{Grade.Trim()}";
        }
    }
}
