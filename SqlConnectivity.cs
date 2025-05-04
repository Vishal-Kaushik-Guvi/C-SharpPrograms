using System;
using MySql.Data.MySqlClient;

class SqlConnectivity
{
    static void Main()
    {
        string connectionString = "Server=localhost;Port=3306;Database=cplus;User ID=root;Password=root";

        using MySqlConnection conn = new MySqlConnection(connectionString);
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM Employee", conn);
        conn.Open();

        using MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }

        conn.Close();
    }
}
