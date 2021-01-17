using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityDAL.Services
{
    public interface IDAO<E>
    {
        public abstract List<E> GetAll();
        public abstract E GetById(int id);
        public abstract bool Update(E entity);
        public abstract bool DeleteById(int id);
        public abstract bool Create(E entity);
    }
}
