# Copilot prompts used to complete this solution.

### PROMPT

> Refactor this CSharp code to POCO

### RESULT

```csharp
using System;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public interface IPersonRepository
{
    Person FindById(int id);
    Person SearchByField(string field, string value);
}

public class PersonRepository : IPersonRepository
{
    private readonly SqlConnection _connection;

    public PersonRepository(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public Person FindById(int id)
    {
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id=@Id", _connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
            }
        }

        return null;
    }

    public Person SearchByField(string field, string value)
    {
        using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE {field}=@value", _connection))
        {
            command.Parameters.AddWithValue("@value", value);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
            }
        }

        return null;
    }
}
```

### PROMPT

> Can you search for problems and fix them?

### RESULT

```csharp
using System;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public interface IPersonRepository
{
    Person FindById(int id);
    Person SearchByField(string field, string value);
}

public class PersonRepository : IPersonRepository
{
    private readonly SqlConnection _connection;

    public PersonRepository(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
    }

    public Person FindById(int id)
    {
        try
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id=@Id", _connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here, e.g. log the error or throw a custom exception
            Console.WriteLine($"Error occurred while executing FindById: {ex.Message}");
        }

        return null;
    }

    public Person SearchByField(string field, string value)
    {
        try
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE {field}=@value", _connection))
            {
                command.Parameters.AddWithValue("@value", value);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here, e.g. log the error or throw a custom exception
            Console.WriteLine($"Error occurred while executing SearchByField: {ex.Message}");
        }

        return null;
    }
}
```

### PROMPT

> Can you apply the SOLID principle to this code?

### RESULT

```csharp
using System;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}

public interface IPersonRepository
{
    Person FindById(int id);
    Person SearchByField(string field, string value);
}

public class PersonRepository : IPersonRepository
{
    private readonly IDatabaseConnection _connection;

    public PersonRepository(IDatabaseConnection connection)
    {
        _connection = connection;
        _connection.Open();
    }

    public Person FindById(int id)
    {
        try
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE Id=@Id", _connection.GetSqlConnection()))
            {
                command.Parameters.AddWithValue("@Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here, e.g. log the error or throw a custom exception
            Console.WriteLine($"Error occurred while executing FindById: {ex.Message}");
        }

        return null;
    }

    public Person SearchByField(string field, string value)
    {
        try
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE {field}=@value", _connection.GetSqlConnection()))
            {
                command.Parameters.AddWithValue("@value", value);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Person() { Id = reader.GetInt32(0), FirstName = reader.GetString(1), LastName = reader.GetString(2), BirthDate = reader.GetDateTime(3) };
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception here, e.g. log the error or throw a custom exception
            Console.WriteLine($"Error occurred while executing SearchByField: {ex.Message}");
        }

        return null;
    }
}

public interface IDatabaseConnection
{
    void Open();
    SqlConnection GetSqlConnection();
}
```
