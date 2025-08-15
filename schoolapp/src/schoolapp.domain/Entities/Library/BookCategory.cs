namespace schoolapp.Domain.Entities.Library
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}