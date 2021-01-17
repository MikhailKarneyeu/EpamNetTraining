using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Exam
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
    }
}
