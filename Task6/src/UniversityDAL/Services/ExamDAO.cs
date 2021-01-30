using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class ExamDAO : IDAO<Exam>
    {
        private readonly string _connectionString;
        public ExamDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Create(Exam entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "INSERT INTO dbo.Exams(SessionID, SubjectID, TeacherID, Date) VALUES (@sessionID, @subjectID, @teacherID, @date)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@sessionID", entity.SessionID);
                    command.Parameters.AddWithValue("@subjectID", entity.SubjectID);
                    command.Parameters.AddWithValue("@teacherID", entity.TeacherID);
                    command.Parameters.AddWithValue("@date", entity.Date);
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
                sqlQuery = "DELETE dbo.Exams WHERE ExamID=@id";
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

        public List<Exam> GetAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            List<Exam> exams = new List<Exam>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT ExamID, SessionID, SubjectID, TeacherID, Date FROM dbo.Exams";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exams.Add(new Exam(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4)));
                        }
                    }
                }
            }
            return exams;
        }

        public Exam GetById(int id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sqlQuery;
            Exam exam = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlQuery = "SELECT ExamID, SessionID, SubjectID, TeacherID, Date FROM dbo.Exams WHERE(ExamID = @id)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exam = new Exam(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4));
                        }
                    }
                }
            }
            return exam;
        }

        public bool Update(Exam entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "UPDATE dbo.Exams SET SessionID = @sessionID, SubjectID = @subjectID, TeacherID = @teacherID, Date = @date WHERE ExamID = @examID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@examID", entity.ExamID);
                    command.Parameters.AddWithValue("@sessionID", entity.SessionID);
                    command.Parameters.AddWithValue("@subjectID", entity.SubjectID);
                    command.Parameters.AddWithValue("@teacherID", entity.TeacherID);
                    command.Parameters.AddWithValue("@date", entity.Date);
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
