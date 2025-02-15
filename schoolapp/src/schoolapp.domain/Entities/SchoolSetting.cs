namespace schoolapp.Domain.Entities
{
    public class SchoolSetting
    {     
        public int Id { get; set; }
        public int ParentSchoolId { get; set; }
        public SchoolTypes SchoolType { get; set; }
        public bool UseSingleName { get; set; }
        public bool IsGroupOfSchools { get; set; }
        public bool UseStreams { get; set; }
        public School School { get; set; }

    }
}
