using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public Group Group { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Student()
        { }
        public Student(int studentID, Group group, string fullName, string gender, DateTime birthDate)
        {
            StudentID = studentID;
            Group = group;
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}
