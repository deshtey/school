namespace schoolapp.Domain.Entities.People
{
    public class HeadTeacher
    {
        public int HeadTeacherId { get; set; }
        public int TeacherId { get; set; }
        public School School { get; set; }
        public Teacher Teacher { get; set; }
    }
}
