using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    public class ExamResultDAOCreator: DAOCreator<ExamResult>
    {
        public override IDAO<ExamResult> Create(string connectionString)
        {
            return new ExamResultDAO(connectionString);
        }
    }
}
