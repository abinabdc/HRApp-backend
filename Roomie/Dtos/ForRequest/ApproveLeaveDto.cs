namespace Roomie.Dtos.ForRequest
{
    public class ApproveLeaveDto
    {
        public int UserId { get; set; }
        public int LeaveId { get; set; }
        public bool Approve { get; set; }
        public string LeaveType { get; set; }
        public int TotalDays { get; set; }

    }
}
