using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Student: IComparable
    {
        public int StudentID { get; set; }
        public int GroupID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Student()
        { }
        public Student(int studentID, int groupID, string fullName, string gender, DateTime birthDate)
        {
            StudentID = studentID;
            GroupID = groupID;
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
        }
        public int CompareTo(object obj)
        {
            if (obj is Student e)
                return this.FullName.CompareTo(e.FullName);
            else
                throw new Exception("Invalid type object.");
        }

        public override bool Equals(object obj)
        {
            if (typeof(Student) != obj.GetType())
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
            return $"{StudentID};{GroupID};{FullName.Trim()};{Gender.Trim()};{BirthDate}";
        }
    }
}
