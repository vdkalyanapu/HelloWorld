using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Apacheta.Utilities.IO;
using Apacheta.Utilities.SqlCe;
using SQLite;

namespace HelloWorld.DAO
{
    public class Database
    {
        private static string databasePath = "";
        public static string DatabasePath 
        {
            get
            {
                return databasePath;
            }
            set
            {
                databasePath = value;
                SqlCeDbApply.PathToDb = databasePath;
            }
        }

        public static SQLiteConnection Open()
        {
            var connection = GetConnection();
            bool log = false;
#if DEBUG
            log = true;
#endif
            return Open(log);
        }

        // be aware that logging the output will noticeably slow down the application
        public static SQLiteConnection Open(bool logOutput)
        {
            var connection = GetConnection();
            connection.Trace = logOutput;
            connection.TimeExecution = logOutput;

            return connection;
        }

        private static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(DatabasePath);
        }

        public static void GenerateTables()
        {
            try
            {
                using (var dbConnection = Open(false))
                {
                    dbConnection.CreateTable<Counter>();
                }
            }
            catch (Exception e)
            {
                AceLogger.LogMessage("Database", AceLogger.LogLevels.EXCEPTION, e.Message + "; " + e.StackTrace);
            }
        }
    }
}
