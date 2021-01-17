using System;
using System.Collections.Generic;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class GroupDAOCreator: DAOCreator<Group>
    {
        public override IDAO<Group> Create(string connectionString)
        {
            return new GroupDAO(connectionString);
        }
    }
}
