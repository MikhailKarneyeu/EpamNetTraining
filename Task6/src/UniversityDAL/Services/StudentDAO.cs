using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class StudentDAO : IDAO<Student>
    {
        private readonly string _connectionString;
        public StudentDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Create(Student entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "INSERT INTO dbo.Students(GroupID, FullName, Gender, BirthDate) VALUES (@groupID, @fullName, @gender, @birthDate)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@groupID", entity.GroupID);
                    command.Parameters.AddWithValue("@fullName", entity.FullName);
                    command.Parameters.AddWithValue("@gender", entity.Gender);
                    command.Parameters.AddWithValue("@birthDate", entity.BirthDate);
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
                sqlQuery = "DELETE dbo.Students WHERE StudentID = @id";
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

        public List<Student> GetAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT StudentID, GroupID, FullName, Gender, BirthDate FROM dbo.Students";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
                        }
                    }
                }
            }
            return students;
        }

        public Student GetById(int id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sqlQuery;
            Student student = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlQuery = "SELECT StudentID, GroupID, FullName, Gender, BirthDate FROM dbo.Students WHERE(StudentID = @id)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student = new Student(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4));
                        }
                    }
                }
            }
            return student;
        }

        public bool Update(Student entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "UPDATE dbo.Students SET GroupID = @groupID, FullName = @fullName, Gender = @gender, BirthDate = @birthDate WHERE StudentID = @studentID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentID", entity.StudentID);
                    command.Parameters.AddWithValue("@groupID", entity.GroupID);
                    command.Parameters.AddWithValue("@fullName", entity.FullName);
                    command.Parameters.AddWithValue("@gender", entity.Gender);
                    command.Parameters.AddWithValue("@birthDate", entity.BirthDate);
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
