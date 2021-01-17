using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using UniversityDAL.Entities;

namespace UniversityDAL.Services
{
    class SessionDAO : IDAO<Session>
    {
        private readonly string _connectionString;
        public SessionDAO(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Create(Session entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "INSERT INTO dbo.Sessions(Name, StartDate, EndDate) VALUE (@name, @startDate, @endDate)";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@startDate", entity.StartDate);
                    command.Parameters.AddWithValue("@endDate", entity.EndDate);
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
                sqlQuery = "DELETE dbo.Sessions WHERE SessionID = @id";
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

        public List<Session> GetAll()
        {
            SqlCommand command;
            SqlDataReader reader;
            List<Session> groups = new List<Session>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM dbo.Sessions";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(new Session(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3)));
                        }
                    }
                }
            }
            return groups;
        }

        public Session GetById(int id)
        {
            SqlCommand command;
            SqlDataReader reader;
            string sqlQuery;
            Session group = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                sqlQuery = "SELECT * FROM dbo.Sessions WHERE SessionId=@id";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            group = new Session(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3));
                        }
                    }
                }
            }
            return group;
        }

        public bool Update(Session entity)
        {
            SqlCommand command;
            string sqlQuery;
            bool result = false;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                sqlQuery = "UPDATE dbo.Sessions SET Name = @name, StartDate = @startDate, EndDate = @endDate WHERE SessionID = @sessionID";
                using (command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@sessionID", entity.SessionID);
                    command.Parameters.AddWithValue("@name", entity.Name);
                    command.Parameters.AddWithValue("@startDate", entity.StartDate);
                    command.Parameters.AddWithValue("@endDate", entity.EndDate);
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
