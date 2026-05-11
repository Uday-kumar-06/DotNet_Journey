using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=true;TrustServerCertificate=True;Encrypt=False;";

        var con = new SqlConnection(connectionString);

        try
        {
            con.Open();

            string query =
                "INSERT INTO Students(Name, Age) VALUES(@name, @age)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", "Bhargav");
            cmd.Parameters.AddWithValue("@age", 23);

            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows + " row inserted");

            ReadStudents(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    static void ReadStudents(string conStr)
    {
        SqlConnection con = new SqlConnection(conStr);

        try
        {
            con.Open();

            string query = "SELECT * FROM Students";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    reader["Id"] + " " +
                    reader["Name"] + " " +
                    reader["Age"]);
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}