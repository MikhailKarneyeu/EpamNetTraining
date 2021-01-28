using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class ExamResultDAO : IDAO<ExamResult>
    {
        private readonly string _connectionString;
        public ExamResultDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Create(ExamResult entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "INSERT INTO dbo.ExamResults(ExamID, StudentID, Grade) VALUES (@examID, @studentID, @grade)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@examID", entity.ExamID);
                    command.Parameters.AddWithValue("@studentID", entity.StudentID);
                    command.Parameters.AddWithValue("@grade", entity.Grade);
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
                sqlQuery = "DELETE dbo.ExamResults WHERE ExamResultID=@id";
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

        public List<ExamResult> GetAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            List<ExamResult> examResults = new List<ExamResult>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT ExamResultID, ExamID, StudentID, Grade FROM dbo.ExamResults";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            examResults.Add(new ExamResult(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3)));
                        }
                    }
                }
            }
            return examResults;
        }

        public ExamResult GetById(int id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sqlQuery;
            ExamResult examResult = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlQuery = "SELECT ExamResultID, ExamID, StudentID, Grade FROM dbo.ExamResults WHERE (ExamResultID = @id)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            examResult = new ExamResult(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));
                        }
                    }
                }
            }
            return examResult;
        }

        public bool Update(ExamResult entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "UPDATE dbo.ExamResults SET ExamID = @examID, StudentID = @studentID, Grade = @grade WHERE ExamResultID = @examResultID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@examResultID", entity.ExamResultID);
                    command.Parameters.AddWithValue("@examID", entity.ExamID);
                    command.Parameters.AddWithValue("@studentID", entity.StudentID);
                    command.Parameters.AddWithValue("@grade", entity.Grade);
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
