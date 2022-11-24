using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options) { }

        public DbSet <tbl_customer> Customer { get; set; }
        public DbSet <tbl_company> Company { get; set; }   
        public DbSet <tbl_action> Action { get; set; }
        public DbSet <tbl_staff> Staff { get; set; }
    }
}
