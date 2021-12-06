using System;

namespace MyLibraryContract.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Avialible { get; set; }
        public int WriteYear { get; set; }
        public DateTime TimeToAddInLibrary { get; set; }

    }
}
