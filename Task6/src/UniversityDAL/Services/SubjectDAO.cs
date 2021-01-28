using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class SubjectDAO: IDAO<Subject>
    {
        private readonly string _connectionString;
        public SubjectDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Create(Subject entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "INSERT INTO dbo.Subjects(Name) VALUES (@name)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", entity.Name);
                    adapter.InsertCommand = command;
                    int rows = adapter.InsertCommand.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            return result;
        }

        public bool DeleteById(int id)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "DELETE dbo.Subjects WHERE SubjectID = @id";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    adapter.DeleteCommand = command;
                    int rows = adapter.DeleteCommand.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            return result;
        }

        public List<Subject> GetAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            List<Subject> subjects = new List<Subject>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM dbo.Subjects";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }
            return subjects;
        }

        public Subject GetById(int id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sqlQuery;
            Subject subject = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlQuery = "SELECT * FROM dbo.Subjects WHERE SubjectId=@id";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subject = new Subject(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            return subject;
        }

        public bool Update(Subject entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "UPDATE dbo.Subjects SET Name = @name WHERE SubjectID = @SubjectID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@SubjectID", entity.SubjectID);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    adapter.InsertCommand = command;
                    int rows = adapter.InsertCommand.ExecuteNonQuery();
                    if (rows > 0)
                        result = true;
                }
            }
            return result;
        }
    }
}
