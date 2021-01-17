using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Session: IComparable
    {
        public int SessionID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Session()
        { }
        public Session(int sessionID, string name, DateTime startDate, DateTime endDate)
        {
            SessionID = sessionID;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
        public int CompareTo(object obj)
        {
            if (obj is Session e)
                return this.Name.CompareTo(e.Name);
            else
                throw new Exception("Invalid type object.");
        }

        public override bool Equals(object obj)
        {
            if (typeof(Session) != obj.GetType())
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
            return $"{SessionID};{Name.Trim()};{StartDate};{EndDate}";
        }
    }
}
