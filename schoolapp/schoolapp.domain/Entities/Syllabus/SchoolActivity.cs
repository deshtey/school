namespace schoolapp.Domain.Entities.Syllabus
{
    public class SchoolActivity
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public TimeOnly Starts { get; set; }
        public TimeOnly Ends { get; set; }
    }
}
