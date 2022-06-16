using Microsoft.Data.Sqlite;

string connectionString = @"Data Source=habit_tracker.db";

CreateDatabase();

void CreateDatabase()
{
    using (var connection = new SqliteConnection(connectionString))
    {
        using (var tableCmd = connection.CreateCommand())
        {
            connection.Open();
            tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS Reading (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";
            tableCmd.ExecuteNonQuery();
        }
    }
    void GetUserInput();
    { 
    
    }
}
