using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public class ConnectionTest
    {
        public static void TestDatabaseConnection()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
                Console.WriteLine("Testing database connection...");
                Console.WriteLine($"Connection String: {connectionString}");
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("✅ Database connection successful!");
                    Console.WriteLine($"Server Version: {connection.ServerVersion}");
                    Console.WriteLine($"Database: {connection.Database}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Database connection failed: {ex.Message}");
                Console.WriteLine("\nTroubleshooting steps:");
                Console.WriteLine("1. Ensure SQL Server is running");
                Console.WriteLine("2. Check if SQL Server Browser service is running");
                Console.WriteLine("3. Verify Windows Authentication is enabled");
                Console.WriteLine("4. Try using 'localhost\\SQLEXPRESS' if you have SQL Server Express");
            }
        }
    }
}
