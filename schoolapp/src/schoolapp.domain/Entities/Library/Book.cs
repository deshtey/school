namespace schoolapp.Domain.Entities.Library
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Edition { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public BookStatus Status { get; set; }
    }

    public enum BookStatus
    {
        Available,
        Issued,
        Reserved,
        Damaged,
        Lost
    }
}