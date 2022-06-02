namespace Roomie.Dtos.ForRequest
{
    public class LeaveDto
    {

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int TotalDays { get; set; }
        public string LeaveType { get; set; }
    }
    public class DateDto
    {
        public DateTime TodayDate { get; set; }
    }
}
