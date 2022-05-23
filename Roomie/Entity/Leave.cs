namespace Roomie.Entity
{
    public class Leave
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; }
        public LeaveType LeaveType { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
