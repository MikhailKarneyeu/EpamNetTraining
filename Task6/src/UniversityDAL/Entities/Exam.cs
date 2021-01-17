using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Exam: IComparable
    {
        public int ExamID { get; set; }
        public Session Session { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Exam()
        {
        }
        public Exam(int examID, Session session, string name, DateTime date)
        {
            ExamID = examID;
            Session = session;
            Name = name;
            Date = date;
        }

        public int CompareTo(object obj)
        {
            if (obj is Exam e)
                return this.Name.CompareTo(e.Name);
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
            return $"{ExamID};{Session};{Name.Trim()};{Date}";
        }
    }
}
