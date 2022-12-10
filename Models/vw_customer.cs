using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerManagementSystem.Models
{
    public class vw_customer
    {
        public int Id { get; set; }
        public string customer_name { get; set; } = String.Empty;
        public string customer_kana { get; set; } = String.Empty;
        public string section { get; set; } = String.Empty;
        public string post { get; set; } = String.Empty;
        public DateTime first_action_date { get; set; }
        public string zipcode { get; set; } = String.Empty;
        public string address { get; set; } = String.Empty;
        public string tel { get; set; } = String.Empty;
        public string memo { get; set; } = String.Empty;
        public DateTime	update_date { get; set; }
        public string update_staff_name { get; set; } = String.Empty;
        public string company_name { get; set; } = String.Empty;
        public string company_kana { get; set; } = String.Empty;
        public string staff_name { get; set; } = String.Empty;
    }
}

