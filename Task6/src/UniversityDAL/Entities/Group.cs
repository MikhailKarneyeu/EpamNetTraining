using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Group: IComparable
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public Group()
        { }
        public Group(int groupID, string name)
        {
            GroupID = groupID;
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
            if (typeof(Group) != obj.GetType())
                return false;
            if (ToString().Equals(obj.ToString()))
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return this.GroupID.GetHashCode() ^ this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GroupID};{Name.Trim()}";
        }
    }
}
