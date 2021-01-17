using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class ExamResult: IComparable
    {
        public int ExamResultID { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public string Grade { get; set; }
        public ExamResult()
        {
        }
        public ExamResult(int examResultID, Exam exam, Student student, string grade)
        {
            ExamResultID = examResultID;
            Exam = exam;
            Student = student;
            Grade = grade;
        }
        public int CompareTo(object obj)
        {
            if (obj is ExamResult e)
                return this.Exam.CompareTo(e.Exam);
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
            return $"{ExamResultID};{Exam};{Student};{Grade.Trim()}";
        }
    }
}
