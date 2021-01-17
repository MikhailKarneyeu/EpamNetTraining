using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class SessionDAOCreator: DAOCreator<Session>
    {
        public override IDAO<Session> Create(string connectionString)
        {
            return new SessionDAO(connectionString);
        }
    }
}
