using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.Models
{
    public class vw_salesReport
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime action_date { get; set; }
        public string? staff_name { get; set; } = String.Empty;
        public string customer_name { get; set; } = String.Empty;
        public string company_name { get; set; } = String.Empty;
        public string? action_content { get; set; } = String.Empty;
    }
}