namespace schoolapp.Domain.Entities.Academics
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<AcademicTerm> Terms { get; set; }
        public bool IsCurrent { get; set; }
        
        // Additional academic year information
        public string? Description { get; set; }
        public AcademicYearStatus Status { get; set; } = AcademicYearStatus.Planning;
        public string? PrincipalRemarks { get; set; }
        
        protected AcademicYear() { }

        public AcademicYear(int schoolId, DateOnly startDate, DateOnly endDate)
        {
            SchoolId = schoolId;
            Name = $"{startDate.Year}-{endDate.Year}";
            StartDate = startDate;
            EndDate = endDate;
            Terms = new List<AcademicTerm>();
        }

        public static AcademicYear CreateWithTerms(int schoolId, DateOnly startDate, DateOnly endDate,
            AcademicTermType termType = AcademicTermType.Semester)
        {
            var academicYear = new AcademicYear(schoolId, startDate, endDate);
            academicYear.GenerateTerms(termType);
            return academicYear;
        }

        // Method to generate terms based on type
        public void GenerateTerms(AcademicTermType termType)
        {
            Terms.Clear();

            switch (termType)
            {
                case AcademicTermType.Semester:
                    GenerateSemesterTerms();
                    break;
                case AcademicTermType.Trimester:
                    GenerateTrimesterTerms();
                    break;
                case AcademicTermType.Quarter:
                    GenerateQuarterTerms();
                    break;
            }
        }

        private void GenerateSemesterTerms()
        {
            var yearSpan = EndDate.DayNumber - StartDate.DayNumber;
            var semesterDays = yearSpan / 2;

            // First Semester
            var firstSemesterEnd = StartDate.AddDays(semesterDays);
            Terms.Add(new AcademicTerm($"First Semester {StartDate.Year}",
                StartDate,
                firstSemesterEnd,
                this));

            // Second Semester
            Terms.Add(new AcademicTerm($"Second Semester {StartDate.Year}",
                firstSemesterEnd.AddDays(1),
                EndDate,
                this));
        }

        private void GenerateTrimesterTerms()
        {
            var yearSpan = EndDate.DayNumber - StartDate.DayNumber;
            var trimesterDays = yearSpan / 3;

            // First Trimester
            var firstTrimesterEnd = StartDate.AddDays(trimesterDays);
            Terms.Add(new AcademicTerm($"First Trimester {StartDate.Year}",
                StartDate,
                firstTrimesterEnd,
                this));

            // Second Trimester
            var secondTrimesterStart = firstTrimesterEnd.AddDays(1);
            var secondTrimesterEnd = secondTrimesterStart.AddDays(trimesterDays);
            Terms.Add(new AcademicTerm($"Second Trimester {StartDate.Year}",
                secondTrimesterStart,
                secondTrimesterEnd,
                this));

            // Third Trimester
            Terms.Add(new AcademicTerm($"Third Trimester {StartDate.Year}",
                secondTrimesterEnd.AddDays(1),
                EndDate,
                this));
        }

        private void GenerateQuarterTerms()
        {
            var yearSpan = EndDate.DayNumber - StartDate.DayNumber;
            var quarterDays = yearSpan / 4;

            string[] quarterNames = { "First Quarter", "Second Quarter", "Third Quarter", "Fourth Quarter" };

            for (int i = 0; i < 4; i++)
            {
                var quarterStart = StartDate.AddDays(i * quarterDays);
                var quarterEnd = i == 3 ? EndDate : StartDate.AddDays((i + 1) * quarterDays - 1);

                Terms.Add(new AcademicTerm($"{quarterNames[i]} {StartDate.Year}",
                    quarterStart,
                    quarterEnd,
                    this));
            }
        }

        public override string ToString() => Name;
    }
    
    public enum AcademicYearStatus
    {
        Planning,
        Active,
        Completed,
        Cancelled
    }
}
