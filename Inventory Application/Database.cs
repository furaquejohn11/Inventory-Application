using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


namespace Inventory_Application
{
    class Database
    {
        public SQLiteConnection myConnection;
        public string strConnection = "Data Source = database.sqlite3";

        public Database()
        {
            if (!File.Exists("./database.sqlite3"))
            {
                myConnection = new SQLiteConnection(strConnection);
                SQLiteConnection.CreateFile("database.sqlite3");
            }
            
        }
    }
}
