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
        string ConnectionString = "";
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
            SqlCommand cmd = new SqlCommand(Query_, connection);
            cmd.ExecuteNonQuery();
        }           
    }
}

