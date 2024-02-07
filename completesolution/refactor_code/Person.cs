using System;
using System.Data.SqlClient;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    private static SqlConnection _connection;

    public Person()
    {
        ConnectToDatabase();
    }

    private void ConnectToDatabase()
    {
        string connetionString = $"Data Source=YOUR_SERVER_ADDRESS;Initial Catalog=YOUR_DATABASE_NAME;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD";
        _connection = new SqlConnection(connetionString);
        _connection.Open();
    }

    public static Person FindById(int id)
    {
        SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id=@Id", _connection);
        command.Parameters.AddWithValue("@Id", id);
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
        }

        return null;
    }

    public static Person SearchByField(string field, string value)
    {
        SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE {field}=@value", _connection);
        command.Parameters.AddWithValue("@value", value);
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
        }

        return null;
    }
}
