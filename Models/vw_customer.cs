namespace CustomerManagementSystem.Models
{
    public class vw_customer
    {
        public int Id { get; set; }
        public string customer_name { get; set; } = String.Empty;
        public string customer_kana { get; set; } = String.Empty;
        public string company_name { get; set; } = String.Empty;
        public string section { get; set; } = String.Empty;
        public string post { get; set; } = String.Empty;
        public string staff_name { get; set; } = String.Empty;
    }
}
