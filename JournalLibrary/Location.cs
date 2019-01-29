using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    public class Location:Database
    {
        public int ID { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public void NewLocation()
        {
            ExecuteQueries($@"INSERT INTO [dbo].[Location]
         ([UserID]
          ,[City]
          ,[State])
          Values('{User.ID}','{City}', '{State}');");
        }

        public List<Location> SelectLocation()
        {
            Output output = new Output();
            return output.GetLocations(User);
        }

        public void UpdateLocation()
        {
            ExecuteQueries($@"UPDATE [dbo].[Location]
             SET 
            ,[City] = {City}
            ,[State] = {State}
            WHERE LocationID = {ID};");
        }
    }
}
