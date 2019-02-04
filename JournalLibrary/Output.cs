using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace JournalLibrary
{
    //Output inherits from Database
    public class Output : Database
    {
        //Method used to return data from the Database 
        public List<Location> GetLocations(User user)
        {
            List<Location> TempList = new List<Location>();
            using (SqlDataReader reader = DataReader($@"SELECT
            [LocationID]
            ,[City]
            ,[State]
            FROM [dbo].[Location]
            WHERE UserID = {user.ID};"))
            {
                while (reader.Read())
                {
                    TempList.Add(new Location
                    {
                        ID = reader.GetInt32(0),
                        City = reader.GetString(1),
                        State = reader.GetString(2),
                    });
                }
            }
            return TempList;
        }

        public List<User> GetUsers(User user)
        {
            List<User> UserList = new List<User>();
            using (SqlDataReader reader = DataReader($@"SELECT
            [UserID]
           ,[UserName]
           ,[Password]
           ,[LastName]
           ,[FirstName]
           ,[MI]
            FROM [dbo].[Users]
            WHERE UserName = '{user.UserName}';"))
            {
                while (reader.Read())
                {
                    UserList.Add(new User
                    {
                        ID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        Password = reader.GetString(2),
                        LastName = reader.GetString(3),
                        FirstName = reader.GetString(4),
                        MI = reader.GetString(5),
                    });
                }
            }
            return UserList;
        }

        public List<Entry> GetEntry(User user)
        {
            List<Entry> EntryList = new List<Entry>();
            using(SqlDataReader reader = DataReader($@"SELECT 
            [Entries].[EntryID]
           ,[Entries].[Title]
           ,[Entries].[EntryText]
           ,[Entries].[EntryDate]
           ,[Entries].[LocationID]
           ,[Location].[City]
           ,[Location].[State]
            FROM Entries 
            JOIN Location ON 
            [Entries].[LocationID] = [Location].[LocationID]
            WHERE [Entries].[UserID] = {user.ID};"))
            {
                while (reader.Read())
                {
                    EntryList.Add(new Entry
                    {
                       ID = reader.GetInt32(0),
                       Title = reader.GetString(1),
                       Text = reader.GetString(2),
                       EntryDate = reader.GetDateTime(3),
                       Location = new Location()
                       {
                            ID = reader.GetInt32(4),
                            City = reader.GetString(5),
                            State = reader.GetString(6),
                       }
                    });
                }
            }
            return EntryList;  
        }
    }
}
