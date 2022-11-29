namespace CustomerManagementSystem.Models
{
    public class Testx
    {
        public int Id { get; set; }
        public string customer_name { get; set; } = String.Empty;
        public string customer_kana { get; set; } = String.Empty;
        public string company_name { get; set; } = String.Empty;
        public string section { get; set; } = String.Empty;
        public string post { get; set; } = String.Empty;
        public string zipcode { get; set; } = String.Empty;
        public string address { get; set; } = String.Empty;
        public string tel { get; set; } = String.Empty;
        public int staff_name { get; set; }
        public DateTime first_action_date { get; set; }
        public string memo { get; set; } = String.Empty;    
    }
}
