using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Text;

namespace UniversityDAL.Entities
{
    [Table(Name = "Specialties")]
    public class Specialty
    {
        [Column(Name = "SpecialtyID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SpecialtyID { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        public Specialty()
        {  }
        public Specialty(int specialtyID, string name)
        {
            SpecialtyID = specialtyID;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            if (typeof(Specialty) != obj.GetType())
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
            return $"{SpecialtyID};{Name}";
        }
    }
}
