using Microsoft.Data.Sqlite;
using System.Globalization;

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

            List<Reading> Readingtabledata = new();

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Readingtabledata.Add(
                    new Reading
                    {
                        Id = reader.GetInt32(0),
                        Date = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    }
                        );
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }

            connection.Close();
            
            Console.WriteLine("-----------------------------------------");
            foreach(var row in Readingtabledata)
            {
                Console.WriteLine($"{row.Id} | {row.Date} | Books Read: {row.Quantity}");
            
            }
            Console.WriteLine("-----------------------------------------");


        }
    }
}

void CreateRecords()
{
    Console.WriteLine("Please provide Date in format mm-dd-yyyy. Type 0 to return to main menu.");
    string date = Console.ReadLine();

    if (date == "0") GetUserInput();

    Console.WriteLine("Please provide the quantity, or amount of times you read today.");
    int quantity = Convert.ToInt32(Console.ReadLine());

    if (quantity == 0) GetUserInput();

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
    
    GetAllRecords();
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
public int Id { get; set; } 
public string? Date { get; set; }
public int Quantity { get; set; }
}

