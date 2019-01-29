using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace JournalLibrary
{
    public class Database
    {
        string ConnectionString = @"Data Source = '.\SQLEXPRESS';Initial Catalog = Journal_Database;Integrated Security = SSPI;";
        SqlConnection connection;

        public void OpenConnection()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = Query_;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public SqlDataReader DataReader(string Query_)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand(Query_, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }
    }
}

