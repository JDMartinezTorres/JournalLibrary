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
        //This string identifies the database location
        string ConnectionString = @"Data Source = '.\SQLEXPRESS';Initial Catalog = Journal_Database;Integrated Security = SSPI;";
        SqlConnection connection;

        //Method that opens database connection
        public void OpenConnection()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        //Method that closes connection
        public void CloseConnection()
        {
            connection.Close();
        }

        //Method the executes queries to the database
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

        //Method that returns data from the database
        public SqlDataReader DataReader(string Query_)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand(Query_, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            return dataReader;
        }
    }
}

