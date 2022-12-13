namespace CustomerManagementSystem.Models
{
    public class tbl_staff
    {
        public int Id { get; set; }
        public string staff_name { get; set; } = string.Empty;
        public string? userId { get; set; } = string.Empty;
        public string? password { get; set; }  = string.Empty;
        public bool? admin_flag { get; set; }
        public bool? delete_flag { get; set; }
    }
}
