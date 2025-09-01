using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Common;
using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Domain.Entities.ClassGrades
{
    [Index(nameof(SchoolId), nameof(Name), IsUnique = true)]
    public class Grade : BaseAuditableEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public ICollection<ClassRoom> ClassRooms { get; set; } = [];

        [Range(0, 100)]
        public double MinimumOverallGradeForPromotion { get; set; } = 60.0;

        [Range(0, 100)]
        public double MinimumGradePerCompulsorySubject { get; set; } = 50.0;

        [Range(1, 20)]
        public int MaxSubjectsPerYear { get; set; } = 8;

        public int GradeLevel { get; set; } // 1 for Grade 1, 2 for Grade 2, etc.
    }
}
