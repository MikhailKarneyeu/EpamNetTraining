using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;
using System.Linq;

namespace UniversityDAL.Services
{
    class SpecialtyDAO: IDAO<Specialty>
    {
        private readonly string _connectionString;
        private DataContext db;
        public SpecialtyDAO(string connectionString)
        {
            _connectionString = connectionString;
            db = new DataContext(_connectionString);
        }
        public bool Create(Specialty entity)
        {

            db.GetTable<Specialty>().InsertOnSubmit(entity);
            db.SubmitChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            var entityToDelete = db.GetTable<Specialty>().First(e => e.SpecialtyID == id);
            if (entityToDelete != null)
            {
                db.GetTable<Specialty>().DeleteOnSubmit(entityToDelete);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public List<Specialty> GetAll()
        {
            return db.GetTable<Specialty>().ToList();
        }

        public Specialty GetById(int id)
        {
            return db.GetTable<Specialty>().First(e => e.SpecialtyID == id);
        }

        public bool Update(Specialty entity)
        {
            var entityToUpdate = db.GetTable<Specialty>().First(e => e.SpecialtyID == entity.SpecialtyID);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
