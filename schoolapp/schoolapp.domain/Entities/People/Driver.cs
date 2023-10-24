using schoolapp.Domain.Entities.Base;

namespace schoolapp.Domain.Entities.People
{
    public class Driver : Person
    {
         public int DriverId { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
