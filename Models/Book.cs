namespace CustomerManagementSystem.Models
{
    public class Bookx
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public bool Sample { get; set; }
    }
}
