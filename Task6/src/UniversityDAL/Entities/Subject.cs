using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public Subject()
        { }
        public Subject(int subjectID, string name)
        {
            SubjectID = subjectID;
            Name = name;
        }
        public int CompareTo(object obj)
        {
            if (obj is Group e)
                return this.Name.CompareTo(e.Name);
            else
                throw new Exception("Invalid type object.");
        }
        public override bool Equals(object obj)
        {
            if (typeof(Subject) != obj.GetType())
                return false;
            if (ToString().Equals(obj.ToString()))
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.SubjectID.GetHashCode() ^ this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{SubjectID};{Name.Trim()}";
        }
    }
}
