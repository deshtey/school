namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoom
    {
        public int ClassRoomId { get; set; }
        public DateTime Year { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
    }
}
