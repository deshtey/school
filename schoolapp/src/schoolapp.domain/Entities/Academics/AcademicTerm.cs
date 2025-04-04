namespace schoolapp.Domain.Entities.Academics
{
    public class AcademicTerm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public AcademicTerm() { }
        public AcademicTerm(string name, DateTime startDate, DateTime endDate, AcademicYear academicYear)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            AcademicYear = academicYear;
        }
    }
}
