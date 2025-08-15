namespace schoolapp.Domain.Entities.Transportation
{
    public class BusStop
    {
        public int Id { get; set; }
        public string StopName { get; set; }
        public string Location { get; set; }
        public int BusRouteId { get; set; }
        public BusRoute BusRoute { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public TimeSpan PickupTime { get; set; }
        public TimeSpan DropTime { get; set; }
        public int Sequence { get; set; }
    }
}