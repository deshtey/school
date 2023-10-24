namespace schoolapp.Domain.Entities.ClassGrades
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
    }
}
