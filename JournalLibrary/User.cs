using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    public class User : Database
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }

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

        public List<User> GetUser(User user)
        {
            Output output = new Output();
            return output.GetUsers(user);
        }

        public void UpdateUser()
        {
            ExecuteQueries($@" UPDATE [dbo].[Users]
            SET [UserName] = {UserName}
               ,[Password] = {Password}
               ,[LastName] = {LastName}
               ,[FirstName] = {FirstName}
               ,[MI] = {MI}
                WHERE UserID = {ID};");
        }
    }
}
