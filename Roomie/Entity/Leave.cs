﻿namespace Roomie.Entity
{
    public class Leave
    {
        public int Id { get; set; }
        public string FromDate { get; set; }
       /* public DateTime ToDate { get; set; }*/
        public int TotalDays { get; set; }
        public string LeaveType { get; set; }
        public bool Approved { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}
