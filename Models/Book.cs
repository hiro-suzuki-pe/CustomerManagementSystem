namespace CustomerManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public Book Sample { get; set; }
    }
}
