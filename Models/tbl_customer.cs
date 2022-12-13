namespace CustomerManagementSystem.Models
{
    public class tbl_customer
    {
        public int Id { get; set; }
        public string customer_name { get; set; } = String.Empty;
        public string customer_kana { get; set; } = String.Empty;
        public int? companyId { get; set; }
        public string? section { get; set; } = String.Empty;
        public string? post { get; set; } = String.Empty;
        public string? zipcode { get; set; } = String.Empty;
        public string? address { get; set; } = String.Empty;
        public string? tel { get; set; } = String.Empty;
        public int? staffId { get; set; }
        public DateTime? first_action_date { get; set; }
        public string? memo { get; set; } = String.Empty;
        public DateTime? input_date { get; set; }
        public string? input_staff_name { get; set; } = String.Empty;
        public DateTime? update_date { get; set; }
        public string? update_staff_name { get; set; } = String.Empty;
        public bool? delete_flag { get; set; }
    }
}
