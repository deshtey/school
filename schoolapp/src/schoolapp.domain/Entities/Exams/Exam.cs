using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Common;
using schoolapp.Domain.Validators;

namespace schoolapp.Domain.Entities.Exams
{
    [Index(nameof(SchoolId), nameof(ExamTypeId))]
    [Index(nameof(StartDate), nameof(EndDate))]
    public class Exam : BaseAuditableEntity
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DateGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        [Required]
        public int ExamTypeId { get; set; }
        public virtual ExamType ExamType { get; set; }

        [Required]
        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        // Additional exam information
        [StringLength(1000)]
        public string? Description { get; set; }

        public ExamStatus ExamStatus { get; set; } = ExamStatus.Scheduled;

        [Range(0, 100)]
        public double? Weightage { get; set; }

        [Range(0, 100)]
        public double? PassingMarks { get; set; }

        [Range(0, 100)]
        public double? MaximumMarks { get; set; }

        [StringLength(50)]
        public string? ExamCode { get; set; }
    }
    
    public enum ExamStatus
    {
        Draft,
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }
}
