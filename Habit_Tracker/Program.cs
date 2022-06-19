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
}

void GetAllRecords()
{
    using (var connection = new SqliteConnection(connectionString))
    {
        using (var tableCmd = connection.CreateCommand())
        {
            connection.Open();
            tableCmd.CommandText = @"Select * from Reading";
            tableCmd.ExecuteNonQuery();

            List<Reading> tabledata = new();

            SqliteDataReader reader = tableCmd.ExecuteReader();

            
        }
    }
}

void CreateRecords()
{
    Console.WriteLine("Please provide Date");
    var date = Console.ReadLine();
    Console.WriteLine("Please provide the quantity, or amount of times you read today.");
    var quantity = Convert.ToInt32(Console.ReadLine());

    using (var connection = new SqliteConnection(connectionString))
    {
        using (var tableCmd = connection.CreateCommand())
        {
            connection.Open();
            tableCmd.CommandText = @"INSERT INTO Reading (Date, Quantity) VALUES (@date,@quantity)";
            tableCmd.Parameters.AddWithValue("@date",date);
            tableCmd.Parameters.AddWithValue("@quantity",quantity);
            tableCmd.ExecuteNonQuery();

        }
    }
}

GetUserInput();

void GetUserInput()
{
    Console.Clear();
    bool closeApp = false;
    while (closeApp == false)
    {
        Console.WriteLine("\nWelcome to the Habit Tracker App");
        Console.WriteLine("\nHow would you like to proceed?");
        Console.WriteLine("\nType 0 to exit the application");
        Console.WriteLine("Type 1 to view all records");
        Console.WriteLine("Type 2 to create a new entry");
        Console.WriteLine("Type 3 to delete an entry");
        Console.WriteLine("Type 4 to update an entry");

        string commandInput = Console.ReadLine();

        switch (commandInput)
        {
            case "0":
                Console.WriteLine("\nGoodBye!\n");
                closeApp = true;
                break;
            case "1":
                GetAllRecords();
                break;
            case "2":
                CreateRecords();
                break;
        }
    }
}

public class Reading
{ 
int Id { get; set; } 
string? Date { get; set; }
int Quantity { get; set; }
}

