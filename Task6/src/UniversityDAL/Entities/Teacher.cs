using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Linq.Mapping;

namespace UniversityDAL.Entities
{
    [Table(Name = "Teachers")]
    public class Teacher: IComparable
    {
        [Column(Name = "TeacherID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TeacherID { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        public Teacher()
        { }
        public Teacher(int teacherID,  string name)
        {
            TeacherID = teacherID;
            Name = name;
        }
        public int CompareTo(object obj)
        {
            if (obj is Teacher e)
                return this.Name.CompareTo(e.Name);
            else
                throw new Exception("Invalid type object.");
        }
        public override bool Equals(object obj)
        {
            if (typeof(Teacher) != obj.GetType())
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
            return $"{TeacherID};{Name.Trim()}";
        }
    }
}
