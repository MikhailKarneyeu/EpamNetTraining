using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Entities
{
    public class Session
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
    }
}
