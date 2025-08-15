using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public int Capacity { get; set; }
        public int? TeacherId { get; set; }
        public List<Student> Students { get; set; } = [];
        public Teacher ClassTeacher { get; set; }
        
        // Additional classroom information
        public string? Stream { get; set; }
        public string? Building { get; set; }
        public string? Description { get; set; }
        public ClassRoomStatus Status { get; set; } = ClassRoomStatus.Active;

        public ClassRoom()
        {
            Students = new List<Student>();
        }

        // Add a student to this classroom
        public bool AddStudent(Student student)
        {
            if (Students.Count >= Capacity)
                return false;

            if (Students.Any(s => s.Id == student.Id))
                return false;

            Students.Add(student);
            student.ClassRoom = this;
            return true;
        }

        // Remove a student from this classroom
        public bool RemoveStudent(Student student)
        {
            if (Students.Any(s => s.Id == student.Id))
            {
                Students.Remove(student);
                student.ClassRoom = null;
                return true;
            }
            return false;
        }

        public override string ToString() => $"{Grade.Name} - {Name}";

        // Check if classroom has capacity
        public bool HasCapacity()
        {
            return Students.Count < Capacity;
        }
    }
    
    public enum ClassRoomStatus
    {
        Active,
        Inactive,
        Closed
    }
}
