using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Library
{
    public class BookIssue
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int LibraryMemberId { get; set; }
        public LibraryMember LibraryMember { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal FineAmount { get; set; }
        public BookIssueStatus Status { get; set; }
        public string Remarks { get; set; }
    }

    public enum BookIssueStatus
    {
        Issued,
        Returned,
        Overdue,
        Lost
    }
}