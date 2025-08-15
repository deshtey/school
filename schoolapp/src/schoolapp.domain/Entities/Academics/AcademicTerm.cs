namespace schoolapp.Domain.Entities.Academics
{
    public class AcademicTerm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        protected AcademicTerm() { }
        public AcademicTerm(string name, DateOnly startDate, DateOnly endDate, AcademicYear academicYear)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            AcademicYear = academicYear;
        }
    }
    public enum AcademicTermType
    {
        Semester,
        Trimester,
        Quarter
    }
}
