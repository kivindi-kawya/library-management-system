using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;
        }

        // Test database connection
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }

        // Create database and table if they don't exist
        public void InitializeDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Create database if it doesn't exist
                    string createDbQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryManagementDB')
                        BEGIN
                            CREATE DATABASE LibraryManagementDB
                        END";
                    
                    using (SqlCommand command = new SqlCommand(createDbQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Switch to the database
                    connection.ChangeDatabase("LibraryManagementDB");

                    // Create Books table if it doesn't exist
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Books' AND xtype='U')
                        BEGIN
                            CREATE TABLE Books (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Title NVARCHAR(255) NOT NULL,
                                Author NVARCHAR(255) NOT NULL,
                                ISBN NVARCHAR(50) UNIQUE,
                                Publisher NVARCHAR(255),
                                Year INT,
                                Quantity INT DEFAULT 1,
                                DateAdded DATETIME DEFAULT GETDATE()
                            )
                        END";

                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization failed: {ex.Message}");
                throw;
            }
        }

        // Add a new book
        public bool AddBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = @"
                        INSERT INTO Books (Title, Author, ISBN, Publisher, Year, Quantity, DateAdded)
                        VALUES (@Title, @Author, @ISBN, @Publisher, @Year, @Quantity, @DateAdded)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Publisher", book.Publisher ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Year", book.Year);
                        command.Parameters.AddWithValue("@Quantity", book.Quantity);
                        command.Parameters.AddWithValue("@DateAdded", book.DateAdded);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
                return false;
            }
        }

        // Get all books
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = "SELECT Id, Title, Author, ISBN, Publisher, Year, Quantity, DateAdded FROM Books ORDER BY Title";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book
                            {
                                Id = reader.GetInt32("Id"),
                                Title = reader.GetString("Title"),
                                Author = reader.GetString("Author"),
                                ISBN = reader.IsDBNull("ISBN") ? null : reader.GetString("ISBN"),
                                Publisher = reader.IsDBNull("Publisher") ? null : reader.GetString("Publisher"),
                                Year = reader.GetInt32("Year"),
                                Quantity = reader.GetInt32("Quantity"),
                                DateAdded = reader.GetDateTime("DateAdded")
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting books: {ex.Message}");
            }

            return books;
        }

        // Get book by ID
        public Book GetBookById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = "SELECT Id, Title, Author, ISBN, Publisher, Year, Quantity, DateAdded FROM Books WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Book
                                {
                                    Id = reader.GetInt32("Id"),
                                    Title = reader.GetString("Title"),
                                    Author = reader.GetString("Author"),
                                    ISBN = reader.IsDBNull("ISBN") ? null : reader.GetString("ISBN"),
                                    Publisher = reader.IsDBNull("Publisher") ? null : reader.GetString("Publisher"),
                                    Year = reader.GetInt32("Year"),
                                    Quantity = reader.GetInt32("Quantity"),
                                    DateAdded = reader.GetDateTime("DateAdded")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting book by ID: {ex.Message}");
            }

            return null;
        }

        // Update book
        public bool UpdateBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = @"
                        UPDATE Books 
                        SET Title = @Title, Author = @Author, ISBN = @ISBN, 
                            Publisher = @Publisher, Year = @Year, Quantity = @Quantity
                        WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", book.Id);
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Publisher", book.Publisher ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Year", book.Year);
                        command.Parameters.AddWithValue("@Quantity", book.Quantity);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book: {ex.Message}");
                return false;
            }
        }

        // Delete book
        public bool DeleteBook(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = "DELETE FROM Books WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book: {ex.Message}");
                return false;
            }
        }

        // Search books by title or author
        public List<Book> SearchBooks(string searchTerm)
        {
            List<Book> books = new List<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.ChangeDatabase("LibraryManagementDB");

                    string query = @"
                        SELECT Id, Title, Author, ISBN, Publisher, Year, Quantity, DateAdded 
                        FROM Books 
                        WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm
                        ORDER BY Title";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book book = new Book
                                {
                                    Id = reader.GetInt32("Id"),
                                    Title = reader.GetString("Title"),
                                    Author = reader.GetString("Author"),
                                    ISBN = reader.IsDBNull("ISBN") ? null : reader.GetString("ISBN"),
                                    Publisher = reader.IsDBNull("Publisher") ? null : reader.GetString("Publisher"),
                                    Year = reader.GetInt32("Year"),
                                    Quantity = reader.GetInt32("Quantity"),
                                    DateAdded = reader.GetDateTime("DateAdded")
                                };
                                books.Add(book);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching books: {ex.Message}");
            }

            return books;
        }
    }
}
