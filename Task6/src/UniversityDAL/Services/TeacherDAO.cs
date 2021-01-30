using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;
using UniversityDAL.Entities;
using System.Linq;

namespace UniversityDAL.Services
{
    public class TeacherDAO : IDAO<Teacher>
    {
        private readonly string _connectionString;
        private DataContext db;
        public TeacherDAO(string connectionString)
        {
            _connectionString = connectionString;
            db = new DataContext(_connectionString);
        }
        public bool Create(Teacher entity)
        {

            db.GetTable<Teacher>().InsertOnSubmit(entity);
            db.SubmitChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            var entityToDelete = db.GetTable<Teacher>().First(e => e.TeacherID == id);
            if (entityToDelete != null)
            {
                db.GetTable<Teacher>().DeleteOnSubmit(entityToDelete);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public List<Teacher> GetAll()
        {
            return db.GetTable<Teacher>().ToList();
        }

        public Teacher GetById(int id)
        {
            return db.GetTable<Teacher>().First(e => e.TeacherID == id);
        }

        public bool Update(Teacher entity)
        {
            Teacher teacher = db.GetTable<Teacher>().First(e => e.TeacherID == entity.TeacherID);
            if (teacher != null)
            {
                teacher.Name = entity.Name;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
