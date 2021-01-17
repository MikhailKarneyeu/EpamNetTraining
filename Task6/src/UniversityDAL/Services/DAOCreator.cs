using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Services
{
    public abstract class DAOCreator<E>
    {
        public abstract IDAO<E> Create(string connectionString);
    }
}
