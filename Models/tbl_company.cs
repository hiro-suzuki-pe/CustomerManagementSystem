namespace CustomerManagementSystem.Models
{
    public class tbl_company
    {
        public int Id { get; set; }
        public string company_name { get; set; } = string.Empty;
        public string company_kana { get; set; } = string.Empty;
        public bool delete_flag { get; set; }
    }
}
