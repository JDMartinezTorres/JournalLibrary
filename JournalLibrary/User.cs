using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    //Class user inherits from database in-order to use database functions
    public class User : Database
    {
        //Properties of this class
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }

        //Method that allows creation of a new user, sets the values needed for the SQL query
        public void NewUser()
        {
            ExecuteQueries($@"INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[LastName]
           ,[FirstName]
           ,[MI])

            Values('{UserName}','{Password}','{FirstName}', '{LastName}', '{MI}');");
        }

        //Method that passes a user and returns the users information
        public List<User> GetUser(User user)
        {
            Output output = new Output();
            return output.GetUsers(user);
        }

        //Method allows the user to modify the information stored on the database
        public void UpdateUser()
        {
            ExecuteQueries($@" UPDATE [dbo].[Users]
            SET [UserName] = '{UserName}'
               ,[Password] = '{Password}'
               ,[LastName] = '{LastName}'
               ,[FirstName] = '{FirstName}'
               ,[MI] = '{MI}'
                WHERE UserID = '{ID}';");
        }

    }
}