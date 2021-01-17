using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class ExamDAOCreator : DAOCreator<Exam>
    {
        public override IDAO<Exam> Create(string connectionString)
        {
            return new ExamDAO(connectionString);
        }
    }
}
