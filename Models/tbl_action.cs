﻿namespace CustomerManagementSystem.Models
{
    public class tbl_action
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public DateTime action_date { get; set; }
        public string action_content { get; set; } = String.Empty;
        public int action_staffId { get; set; }
    }
}

