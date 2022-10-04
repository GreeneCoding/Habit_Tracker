Habit_Tracker

Creating my first Console App in C#:


<H4>Requirements as defined on The C# Academy</H4>

    1. This is an application where you’ll register one habit.
    2. This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
    3. The application should store and retrieve data from a real database.
    4. When the application starts, it should create a sqlite database, if one isn’t present.
    5. It should also create a table in the database, where the habit will be logged.
    6. The app should show the user a menu of options.
    7. The users should be able to insert, delete, update and view their logged habit.
    8. You should handle all possible errors so that the application never crashes.
    9. The application should only be terminated when the user inserts 0.
    10. You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.
    11. Your project needs to contain a Read Me file where you'll explain how your app works.
    
<H4>Creating our app database</H4>
First we define a SQLite db connection string, then using the CreateDatabase() method, the Habit_Tracker app starts by checking if the "reading" SQLite table exists and, if it does not exist, creates it with the following columns; "Id" (Integer, Autoincrementing Primary Key), "Date" (Text), "Quantity" (Integer).

<H4>Collecting User Input via Menu</H4>

Using the GetUserInput() method, A while loop is used to determine if the app is running, and while the app is running, a switch statement is used to collect user input for deciding to complete one of the following actions; selecting all records from the SQLite database, creating a new record in the database, deleting a record in the database, updating a record in the database, or exiting the app.
    
<H4>Selecting All database entries</H4>

The GetAllRecords() is creating a connection to the SQLite database defined in our connection string, then selecting all records from the reading table we created when we first start our app and displaying the records in the console. 

We created a Reading class to define the members with types that match our SQL table fields, Id, Date, Quantity, then created a Reading list that is used to collect all rows read from the Reading table via the select statement. An if statement is used to check if there is any data returned from the select statement, and then a while loop and boolean is used to add the rows to the Reading list until there are no more rows read. When no more rows are found during the while loop the boolean changes to false, a message is returned and then a foreach loop is used to display the contents of our Reading List.

<H4>Inserting Database Entries</H4>

The CreateRecords() method is used to collect user input (date and quantity) and then pass it into our inert SQL statement using paremeterized SQL to create records in our SQLite database. 

The GetDateInput() method prompts the user for the date we will be using in our insert statement, and we are checking the input first with an if statement to see if it is "0" and then returning the user to our GetUserInput() method if true. After the IF statement we then use a while loop to determine if the input is a date or not, if its not a date, an invalid message is returned and we ask for the date again, if it is a date matching our format, we return the date to be used in our CreateRecords() method.

The GetQuantityInput() method prompts the user for the quantity we will be using in our insert statement. First we Check if the input is 0, and if so, we send them back to GetUserInput(). If the input is not 0, we check that the input is a number and while 
                

<H4>Deleting Database Entries</H4>

<H4>Updating Database Entries</H4>

