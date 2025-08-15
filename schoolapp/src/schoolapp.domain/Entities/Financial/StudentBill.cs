using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Financial
{
    public class StudentBill
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public BillStatus Status { get; set; }
        public string? Remarks { get; set; }
    }

    public enum BillStatus
    {
        Pending,
        PartiallyPaid,
        Paid,
        Overdue,
        Cancelled
    }
}