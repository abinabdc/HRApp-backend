namespace Roomie.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Time { get; set; }
        public string LocationType { get; set; } //Indoors, Outdoors
        public string Location { get; set; }

        public List<User_Event> Going { get; set; }
    }
}
