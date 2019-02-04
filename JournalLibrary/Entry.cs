using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalLibrary
{
    //Entry class inherits from Database allowing it to use functions from database class
    public class Entry:Database
    {
        //Class properties set
        public int ID { get; set; }
        public User User { get; set; }
        public Location Location{ get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime EntryDate { get; set; }

        //Method to create a new entry for the user
        public void NewEntry()
        {
            ExecuteQueries($@"INSERT INTO [dbo].[Entries]
           ([UserID]
           ,[LocationID]
           ,[Title]
           ,[EntryText]
           ,[EntryDate])
            Values('{User.ID}','{Location.ID}','{Title}','{Text}','{EntryDate.ToShortDateString()}');");
        }

        //Method that returns entires that the user has created
        public List<Entry>GetEntry(User user)
        {
            Output output = new Output();
            return output.GetEntry(user);
        }

        //Method allows the use to update entry 
        public void UpdateEntry()
        {
            ExecuteQueries($@" Update [dbo].[Entries]
            SET [Title] = '{Title}',
                [EntryText] = '{Text}',
                [EntryDate] = '{EntryDate}'
            WHERE [Entries].[EntryID] = '{ID}';");
        }
    }
}
