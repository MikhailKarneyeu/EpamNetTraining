using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    public class TeacherDAOCreator: DAOCreator<Teacher>
    {
        public override IDAO<Teacher> Create(string connectionString)
        {
            return new TeacherDAO(connectionString);
        }
    }
}
