namespace Roomie.Dtos.ForRequest
{
    public class ReqEventDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Time { get; set; }
        public string LocationType { get; set; } //Indoors, Outdoors
        public string Location { get; set; }

    }
    public class ReqGoingDto
    {
        /*public int UserId { get; set; }*/
        public int EventId { get; set; }
    }
}
