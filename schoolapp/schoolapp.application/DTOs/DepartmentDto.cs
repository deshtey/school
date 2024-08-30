namespace schoolapp.Application.DTOs
{
    public class DepartmentDto
    {
        public int? Id { get; set; }
        public int SchoolId { get; set; }
        public string DepartmentName { get; set; }
        public int? DepartmentHead { get; set; }
    }
}
