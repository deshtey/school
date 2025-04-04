using schoolapp.Domain.Entities.Academics;

namespace schoolapp.Domain.Entities.Exams
{
    public class Assessment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentSubject StudentSubject { get; set; }
        public double Grade { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }

        public Assessment(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
