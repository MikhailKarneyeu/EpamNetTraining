using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Group
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
    }
}
