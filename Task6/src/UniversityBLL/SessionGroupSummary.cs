using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityBLL
{
    public class SessionGroupSummary
    {
        public Group Group { get; set; }
        public double AverageGrade { get; set; }
        public double MinGrade { get; set; }
        public double MaxGrade { get; set; }
    }
}
