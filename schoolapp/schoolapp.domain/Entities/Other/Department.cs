namespace schoolapp.Domain.Entities.Other
{
    public class Department
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentHead { get; set; }
    }
}
