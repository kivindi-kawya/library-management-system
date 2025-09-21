using System;

namespace Library_Management_System
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public Book()
        {
            DateAdded = DateTime.Now;
        }

        public Book(string title, string author, string isbn, string publisher, int year, int quantity)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Publisher = publisher;
            Year = year;
            Quantity = quantity;
            DateAdded = DateTime.Now;
        }
    }
}
