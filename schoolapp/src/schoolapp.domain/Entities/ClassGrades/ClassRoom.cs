using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Common;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Entities.ClassGrades
{
    [Index(nameof(GradeId), nameof(Name), IsUnique = true)]
    [Index(nameof(TeacherId), nameof(Status))]
    public class ClassRoom : BaseAuditableEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; } = 30;

        public int? TeacherId { get; set; }
        public List<Student> Students { get; set; } = [];
        public Teacher? ClassTeacher { get; set; }

        // Additional classroom information
        [StringLength(20)]
        public string? Stream { get; set; }

        [StringLength(50)]
        public string? Building { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

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
