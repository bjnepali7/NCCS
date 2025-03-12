using System;
using System.Data.SqlClient;

namespace bijaypracticle2.Properties
{
    internal class CRUDoperation
    {
        string cs = "Data Source=DESKTOP-U7SCV47\\SQLEXPRESS;Initial Catalog=db_nccsb;Integrated Security=True;TrustServerCertificate=True";

        public void CreateTable()
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string createTableQuery = "CREATE TABLE tbl_registration (id INT PRIMARY KEY, username VARCHAR(50), password VARCHAR(50), repassword VARCHAR(50), gender VARCHAR(50), course VARCHAR(50), country VARCHAR(50))";
                    SqlCommand cmd = new SqlCommand(createTableQuery, sc);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully!!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

        public void InsertRecord()
        {
            try
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                Console.Write("Re-enter Password: ");
                string repassword = Console.ReadLine();
                Console.Write("Gender: ");
                string gender = Console.ReadLine();
                Console.Write("Course: ");
                string course = Console.ReadLine();
                Console.Write("Country: ");
                string country = Console.ReadLine();

                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string insertQuery = "INSERT INTO tbl_registration (id, username, password, repassword, gender, course, country) VALUES (@id, @username, @password, @repassword, @gender, @course, @country)";
                    SqlCommand cmd = new SqlCommand(insertQuery, sc);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@repassword", repassword);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@course", course);
                    cmd.Parameters.AddWithValue("@country", country);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record inserted successfully!!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

        public void DisplayAllRecords()
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string disQuery = "SELECT * FROM tbl_registration";
                    SqlCommand cmd = new SqlCommand(disQuery, sc);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Username: {reader["username"]}, Gender: {reader["gender"]}, Course: {reader["course"]}, Country: {reader["country"]}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

        public void UpdateRecord()
        {
            try
            {
                Console.Write("Enter ID of the user to update: ");
                int updateId = int.Parse(Console.ReadLine());
                Console.Write("Enter new username: ");
                string newUsername = Console.ReadLine();
                Console.Write("Enter new course: ");
                string newCourse = Console.ReadLine();

                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string updateQuery = "UPDATE tbl_registration SET username = @username, course = @course WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(updateQuery, sc);
                    cmd.Parameters.AddWithValue("@id", updateId);
                    cmd.Parameters.AddWithValue("@username", newUsername);
                    cmd.Parameters.AddWithValue("@course", newCourse);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Record updated successfully!!");
                    else
                        Console.WriteLine("No record found with the given ID.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

        public void DeleteRecord()
        {
            try
            {
                Console.Write("Enter ID of the user to delete: ");
                int deleteId = int.Parse(Console.ReadLine());

                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string deleteQuery = "DELETE FROM tbl_registration WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(deleteQuery, sc);
                    cmd.Parameters.AddWithValue("@id", deleteId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Record deleted successfully!!");
                    else
                        Console.WriteLine("No record found with the given ID.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }

        public void DisplayMaleUsersFromNepal()
        {
            try
            {
                using (SqlConnection sc = new SqlConnection(cs))
                {
                    sc.Open();
                    string selectQuery = "SELECT * FROM tbl_registration WHERE gender = 'Male' AND country = 'Nepal'";
                    SqlCommand cmd = new SqlCommand(selectQuery, sc);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("Male Users from Nepal:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}, Username: {reader["username"]}, Course: {reader["course"]}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
        }
    }
}
