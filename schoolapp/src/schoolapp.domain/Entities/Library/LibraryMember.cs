using schoolapp.Domain.Entities.Base;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Library
{
    public class LibraryMember
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string MemberId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public LibraryMemberStatus Status { get; set; }
        public int BooksIssued { get; set; }
        public decimal OutstandingFines { get; set; }
        public ICollection<BookIssue> BookIssues { get; set; } = new List<BookIssue>();
    }

    public enum LibraryMemberStatus
    {
        Active,
        Inactive,
        Suspended,
        Expired
    }
}