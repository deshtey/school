

namespace schoolapp.Domain.Entities.People
{
    public class StudentParent
    {
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        public ParentType ParentType { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public virtual Student Student { get; internal set; }
        public virtual Parent Parent { get; internal set; }

    }

}
