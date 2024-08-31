namespace schoolapp.Domain.Entities.Syllabus
{
    internal class SubjectTeacher
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }

    }
}
