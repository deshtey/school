using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.Financial
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int StudentBillId { get; set; }
        public StudentBill StudentBill { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Remarks { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        BankTransfer,
        MobileMoney,
        Cheque,
        CreditCard
    }
}