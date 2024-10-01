namespace schoolapp.Domain.Entities.Academics
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public SchoolTypes SchoolType { get; set; }
    }
}
