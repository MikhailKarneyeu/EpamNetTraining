using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    public class SpecialtyDAOCreator: DAOCreator<Specialty>
    {
        public override IDAO<Specialty> Create(string connectionString)
        {
            return new SpecialtyDAO(connectionString);
        }
    }
}
