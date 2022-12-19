using System.ComponentModel.DataAnnotations;

namespace CustomerManagementSystem.Models
{
    public class tbl_action
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime action_date { get; set; }
        public string? action_content { get; set; } = String.Empty;
        public int? action_staffId { get; set; }
    }
}

