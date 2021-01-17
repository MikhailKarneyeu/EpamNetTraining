using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    public class StudentDAOCreator: DAOCreator<Student>
    {
        public override IDAO<Student> Create(string connectionString)
        {
            return new StudentDAO(connectionString);
        }
    }
}
