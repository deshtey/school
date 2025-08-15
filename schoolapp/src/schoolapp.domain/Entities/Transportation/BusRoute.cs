namespace schoolapp.Domain.Entities.Transportation
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public ICollection<BusStop> BusStops { get; set; } = new List<BusStop>();
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public RouteStatus Status { get; set; }
    }

    public enum RouteStatus
    {
        Active,
        Inactive
    }
}