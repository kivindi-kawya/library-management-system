# Library Management System

A simple Windows Forms application for managing library books using C# and SQL Server.

## Features

- **Add Book**: Add new books to the library
- **View All Books**: Display all books in the library
- **Search Books**: Search books by title or author
- **Update Book**: Modify existing book information
- **Delete Book**: Remove books from the library

## Prerequisites

- Visual Studio 2017 or later
- .NET Framework 4.7.2 or later
- SQL Server (LocalDB, Express, or Full version)

## Setup Instructions

### 1. Database Setup

1. Open SQL Server Management Studio (SSMS) or use SQL Server command line
2. Run the `DatabaseSetup.sql` script to create the database and sample data
3. Alternatively, the application will automatically create the database and table on first run

### 2. Connection String Configuration

The application uses Windows Authentication by default. If you need to use SQL Server Authentication, update the connection string in `App.config`:

```xml
<connectionStrings>
    <add name="LibraryDB" 
         connectionString="Data Source=localhost;Initial Catalog=LibraryManagementDB;User ID=your_username;Password=your_password;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Build and Run

1. Open the solution in Visual Studio
2. Build the solution (Ctrl+Shift+B)
3. Run the application (F5)

## Usage

1. **Adding a Book**: Fill in the book details and click "Add Book"
2. **Viewing Books**: Click "View All" to see all books in the list
3. **Searching**: Enter search terms and click "Search"
4. **Updating**: Select a book from the list, modify details, and click "Update"
5. **Deleting**: Select a book and click "Delete" (with confirmation)

## Database Schema

### Books Table
- `Id` (INT, Primary Key, Identity)
- `Title` (NVARCHAR(255), Required)
- `Author` (NVARCHAR(255), Required)
- `ISBN` (NVARCHAR(50), Unique)
- `Publisher` (NVARCHAR(255))
- `Year` (INT)
- `Quantity` (INT, Default: 1)
- `DateAdded` (DATETIME, Default: Current Date)

## Troubleshooting

### Common Issues

1. **Database Connection Failed**
   - Ensure SQL Server is running
   - Check connection string in App.config
   - Verify database exists

2. **Permission Denied**
   - Ensure your Windows account has access to SQL Server
   - Or update connection string to use SQL Server Authentication

3. **Table Not Found**
   - Run the DatabaseSetup.sql script
   - Or let the application create the table automatically

## Project Structure

- `Book.cs` - Book model class
- `DatabaseHelper.cs` - Database operations and CRUD methods
- `Form1.cs` - Main form with UI logic
- `Form1.Designer.cs` - Form design and controls
- `Program.cs` - Application entry point
- `App.config` - Configuration including connection string

## Notes

- The application automatically creates the database and table on first run
- All database operations include proper error handling
- Input validation ensures data integrity
- The UI provides real-time status updates
