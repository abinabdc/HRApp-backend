namespace Roomie.Entity
{
    public class User_Event
    {
        public int AppUserId { get; set; }
        public AppUser User { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

       
    }
}
