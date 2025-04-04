namespace schoolapp.Domain.Entities.Academics
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<AcademicTerm> Terms { get; set; }
        public bool IsCurrent { get; set; }

        public AcademicYear() { }
        public AcademicYear(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString() => Name;
    }
}
