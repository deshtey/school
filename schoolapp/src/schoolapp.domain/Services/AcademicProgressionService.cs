using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Services
{
    public class AcademicProgressionService : IAcademicProgressionService
    {
        public Result<StudentPromotion> CalculatePromotion(Student student, AcademicYear year)
        {
            if (student == null)
                return Result<StudentPromotion>.Failure("Student cannot be null");

            if (year == null)
                return Result<StudentPromotion>.Failure("Academic year cannot be null");

            if (student.ClassRoom == null)
                return Result<StudentPromotion>.Failure("Student must be assigned to a classroom");

            var promotionScore = CalculatePromotionScore(student, year);
            if (!promotionScore.IsSuccess)
                return Result<StudentPromotion>.Failure(promotionScore.Error);

            var nextGrade = DetermineNextGrade(student);
            if (!nextGrade.IsSuccess)
                return Result<StudentPromotion>.Failure(nextGrade.Error);

            var eligibility = ValidatePromotionEligibility(student);
            if (!eligibility.IsSuccess)
                return Result<StudentPromotion>.Failure(eligibility.Error);

            var promotion = new StudentPromotion
            {
                Student = student,
                CurrentGrade = student.ClassRoom.Grade,
                NextGrade = nextGrade.Value,
                PromotionScore = promotionScore.Value,
                IsEligible = eligibility.Value,
                Comments = GeneratePromotionComments(student, promotionScore.Value, eligibility.Value)
            };

            return Result<StudentPromotion>.Success(promotion);
        }

        public Result<bool> ValidatePromotionEligibility(Student student)
        {
            if (student == null)
                return Result<bool>.Failure("Student cannot be null");

            if (student.StudentStatus != StudentStatus.Active)
                return Result<bool>.Failure("Only active students can be promoted");

            if (student.ClassRoom == null)
                return Result<bool>.Failure("Student must be assigned to a classroom");

            // Check minimum attendance (assuming 80% required)
            // This would need actual attendance data
            // For now, return true
            return Result<bool>.Success(true);
        }

        public Result<Grade> DetermineNextGrade(Student student)
        {
            if (student == null)
                return Result<Grade>.Failure("Student cannot be null");

            if (student.ClassRoom?.Grade == null)
                return Result<Grade>.Failure("Student must be assigned to a grade");

            // This would need a proper grade progression logic
            // For now, return the current grade (would need to be enhanced)
            return Result<Grade>.Success(student.ClassRoom.Grade);
        }

        public Result<double> CalculatePromotionScore(Student student, AcademicYear year)
        {
            if (student == null)
                return Result<double>.Failure("Student cannot be null");

            if (year == null)
                return Result<double>.Failure("Academic year cannot be null");

            // Calculate based on enrolled subjects and their grades
            var currentSubjects = student.GetCurrentSubjects(year);
            if (!currentSubjects.Any())
                return Result<double>.Failure("No subjects found for the academic year");

            var gradedSubjects = currentSubjects.Where(s => s.FinalGrade.HasValue).ToList();
            if (!gradedSubjects.Any())
                return Result<double>.Failure("No graded subjects found");

            var averageGrade = gradedSubjects.Average(s => s.FinalGrade!.Value);
            return Result<double>.Success(averageGrade);
        }

        private string GeneratePromotionComments(Student student, double score, bool isEligible)
        {
            var comments = $"Promotion Score: {score:F2}. ";

            if (isEligible)
            {
                comments += "Student meets all promotion criteria.";
            }
            else
            {
                comments += "Student does not meet promotion criteria.";
            }

            return comments;
        }
    }
}