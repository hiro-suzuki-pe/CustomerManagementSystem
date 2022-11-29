﻿using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options): base(options) { }

        public DbSet <tbl_customer> Customer { get; set; }
        public DbSet <tbl_company> Company { get; set; }   
        public DbSet <tbl_action> Action { get; set; }
        public DbSet <tbl_staff> Staff { get; set; }
//        public DbSet<CustomerManagementSystem.Models.Testx> Test { get; set; }
        public DbSet<Testx> Test { get; set; }
    }
}
