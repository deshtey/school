namespace schoolapp.Domain.Enums
{
    public enum EntityStatus : short
    {
        Deleted = -1,
        Inactive = 0,
        Active = 1
    }

    public static class EntityStatusExtensions
    {
        public static string ToFriendlyString(this EntityStatus status)
        {
            switch (status)
            {
                case EntityStatus.Active: return "Active";
                case EntityStatus.Inactive: return "Inactive";
                case EntityStatus.Deleted: return "Deleted";
                default: return "Unknown";
            }
        }

    }
}
