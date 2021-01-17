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
                    command.Parameters.AddWithValue("@examID", entity.Exam.ExamID);
                    command.Parameters.AddWithValue("@studentID", entity.Student.StudentID);
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
                string sqlQuery = "SELECT dbo.ExamResults.ExamResultID, dbo.ExamResults.ExamID, dbo.Exams.SessionID, dbo.Sessions.Name, dbo.Sessions.StartDate, dbo.Sessions.EndDate, dbo.Exams.Name AS SessionName, dbo.Exams.Date, dbo.ExamResults.StudentID, dbo.Students.GroupID, dbo.Groups.Name " +
                    "AS GroupName, dbo.Students.FullName, dbo.Students.Gender, dbo.Students.BirthDate, dbo.ExamResults.Grade " +
                    "FROM dbo.ExamResults INNER JOIN" +
                    " dbo.Exams ON dbo.ExamResults.ExamID = dbo.Exams.ExamID INNER JOIN" +
                    " dbo.Sessions ON dbo.Exams.SessionID = dbo.Sessions.SessionID INNER JOIN" +
                    " dbo.Students ON dbo.ExamResults.StudentID = dbo.Students.StudentID INNER JOIN" +
                    " dbo.Groups ON dbo.Students.GroupID = dbo.Groups.GroupID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            examResults.Add(new ExamResult(reader.GetInt32(0), new Exam(reader.GetInt32(1), new Session(reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5)), reader.GetString(6), reader.GetDateTime(7)), 
                                new Student(reader.GetInt32(8), new Group(reader.GetInt32(9), reader.GetString(10)), reader.GetString(11), reader.GetString(12), reader.GetDateTime(13)), reader.GetString(14)));
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
                sqlQuery = "SELECT dbo.ExamResults.ExamResultID, dbo.ExamResults.ExamID, dbo.Exams.SessionID, dbo.Sessions.Name, dbo.Sessions.StartDate, dbo.Sessions.EndDate, dbo.Exams.Name AS SessionName, dbo.Exams.Date, dbo.ExamResults.StudentID, dbo.Students.GroupID, dbo.Groups.Name " +
                    "AS GroupName, dbo.Students.FullName, dbo.Students.Gender, dbo.Students.BirthDate, dbo.ExamResults.Grade " +
                    "FROM dbo.ExamResults INNER JOIN" +
                    " dbo.Exams ON dbo.ExamResults.ExamID = dbo.Exams.ExamID INNER JOIN" +
                    " dbo.Sessions ON dbo.Exams.SessionID = dbo.Sessions.SessionID INNER JOIN" +
                    " dbo.Students ON dbo.ExamResults.StudentID = dbo.Students.StudentID INNER JOIN" +
                    " dbo.Groups ON dbo.Students.GroupID = dbo.Groups.GroupID " +
                    "WHERE  (dbo.ExamResults.ExamResultID = @id)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            examResult = new ExamResult(reader.GetInt32(0), new Exam(reader.GetInt32(1), new Session(reader.GetInt32(2), reader.GetString(3), reader.GetDateTime(4), reader.GetDateTime(5)), reader.GetString(6), reader.GetDateTime(7)),
                                new Student(reader.GetInt32(8), new Group(reader.GetInt32(9), reader.GetString(10)), reader.GetString(11), reader.GetString(12), reader.GetDateTime(13)), reader.GetString(14));
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
                    command.Parameters.AddWithValue("@examID", entity.Exam.ExamID);
                    command.Parameters.AddWithValue("@studentID", entity.Student.StudentID);
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
