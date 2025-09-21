-- Library Management System Database Setup Script
-- Run this script in SQL Server Management Studio or SQL Server command line

-- Create the database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LibraryManagementDB')
BEGIN
    CREATE DATABASE LibraryManagementDB
END
GO

-- Use the database
USE LibraryManagementDB
GO

-- Create the Books table
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
END
GO

-- Insert some sample data
INSERT INTO Books (Title, Author, ISBN, Publisher, Year, Quantity)
VALUES 
    ('The Great Gatsby', 'F. Scott Fitzgerald', '978-0-7432-7356-5', 'Scribner', 1925, 3),
    ('To Kill a Mockingbird', 'Harper Lee', '978-0-06-112008-4', 'J.B. Lippincott & Co.', 1960, 2),
    ('1984', 'George Orwell', '978-0-452-28423-4', 'Secker & Warburg', 1949, 4),
    ('Pride and Prejudice', 'Jane Austen', '978-0-14-143951-8', 'T. Egerton, Whitehall', 1813, 2),
    ('The Catcher in the Rye', 'J.D. Salinger', '978-0-316-76948-0', 'Little, Brown and Company', 1951, 1)
GO

PRINT 'Database setup completed successfully!'
PRINT 'You can now run the Library Management System application.'
