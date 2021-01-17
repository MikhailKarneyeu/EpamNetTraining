using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class ExamResult
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
    }
}
