using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1: Form
    {
        private DatabaseHelper dbHelper;
        private List<Book> books;
        private Book selectedBook;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            books = new List<Book>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Test database connection
                if (dbHelper.TestConnection())
                {
                    lblStatus.Text = "Status: Database connected successfully";
                    lblStatus.ForeColor = Color.Green;
                    
                    // Initialize database and create tables
                    dbHelper.InitializeDatabase();
                    
                    // Load all books
                    LoadBooks();
                }
                else
                {
                    lblStatus.Text = "Status: Database connection failed";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error initializing application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                books = dbHelper.GetAllBooks();
                lstBooks.Items.Clear();
                
                foreach (Book book in books)
                {
                    lstBooks.Items.Add($"{book.Id} - {book.Title} by {book.Author}");
                }
                
                lblStatus.Text = $"Status: Loaded {books.Count} books";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error loading books - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error loading books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    Book newBook = new Book(
                        txtTitle.Text.Trim(),
                        txtAuthor.Text.Trim(),
                        txtISBN.Text.Trim(),
                        txtPublisher.Text.Trim(),
                        int.Parse(txtYear.Text.Trim()),
                        int.Parse(txtQuantity.Text.Trim())
                    );

                    if (dbHelper.AddBook(newBook))
                    {
                        ClearFields();
                        LoadBooks();
                        lblStatus.Text = "Status: Book added successfully";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Status: Failed to add book";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error adding book - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error adding book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Please select a book to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateInput())
                {
                    selectedBook.Title = txtTitle.Text.Trim();
                    selectedBook.Author = txtAuthor.Text.Trim();
                    selectedBook.ISBN = txtISBN.Text.Trim();
                    selectedBook.Publisher = txtPublisher.Text.Trim();
                    selectedBook.Year = int.Parse(txtYear.Text.Trim());
                    selectedBook.Quantity = int.Parse(txtQuantity.Text.Trim());

                    if (dbHelper.UpdateBook(selectedBook))
                    {
                        ClearFields();
                        LoadBooks();
                        selectedBook = null;
                        lblStatus.Text = "Status: Book updated successfully";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Status: Failed to update book";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error updating book - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error updating book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Please select a book to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedBook.Title}' by {selectedBook.Author}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (dbHelper.DeleteBook(selectedBook.Id))
                    {
                        ClearFields();
                        LoadBooks();
                        selectedBook = null;
                        lblStatus.Text = "Status: Book deleted successfully";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblStatus.Text = "Status: Failed to delete book";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error deleting book - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error deleting book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadBooks();
                    return;
                }

                books = dbHelper.SearchBooks(searchTerm);
                lstBooks.Items.Clear();
                
                foreach (Book book in books)
                {
                    lstBooks.Items.Add($"{book.Id} - {book.Title} by {book.Author}");
                }
                
                lblStatus.Text = $"Status: Found {books.Count} books matching '{searchTerm}'";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error searching books - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show($"Error searching books: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstBooks.SelectedIndex >= 0)
                {
                    int selectedIndex = lstBooks.SelectedIndex;
                    if (selectedIndex < books.Count)
                    {
                        selectedBook = books[selectedIndex];
                        PopulateFields(selectedBook);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Status: Error selecting book - {ex.Message}";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void PopulateFields(Book book)
        {
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtISBN.Text = book.ISBN ?? "";
            txtPublisher.Text = book.Publisher ?? "";
            txtYear.Text = book.Year.ToString();
            txtQuantity.Text = book.Quantity.ToString();
        }

        private void ClearFields()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtPublisher.Clear();
            txtYear.Clear();
            txtQuantity.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please enter an author.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }

            if (!int.TryParse(txtYear.Text, out int year) || year < 1000 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Please enter a valid year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity (0 or greater).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return false;
            }

            return true;
        }
    }
}
