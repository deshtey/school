using schoolapp.Domain.Entities.Academics;
using schoolapp.Domain.Entities.ClassGrades;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Domain.Services
{
    public interface IAcademicProgressionService
    {
        Result<StudentPromotion> CalculatePromotion(Student student, AcademicYear year);
        Result<bool> ValidatePromotionEligibility(Student student);
        Result<Grade> DetermineNextGrade(Student student);
        Result<double> CalculatePromotionScore(Student student, AcademicYear year);
    }

    public class StudentPromotion
    {
        public Student Student { get; set; }
        public Grade CurrentGrade { get; set; }
        public Grade NextGrade { get; set; }
        public double PromotionScore { get; set; }
        public bool IsEligible { get; set; }
        public string Comments { get; set; }
    }

    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, Error = error };
    }
}