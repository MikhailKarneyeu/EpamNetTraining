using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    public class SubjectDAOCreator : DAOCreator<Subject>
    {
        public override IDAO<Subject> Create(string connectionString)
        {
            return new SubjectDAO(connectionString);
        }
    }
}
