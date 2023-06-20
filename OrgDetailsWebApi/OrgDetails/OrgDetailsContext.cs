using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrgDetails
{
    public class OrgDetailsContext:DbContext
    {
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public OrgDetailsContext(DbContextOptions<OrgDetailsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>().HasData(new EmployeeDetail { Id = 1, FirstName = "Steve", LastName = "William", Email = "steve.william@dummy.com" });
            modelBuilder.Entity<EmployeeDetail>().HasData(new EmployeeDetail { Id = 2, FirstName = "Mark", LastName = "Taylor", Email = "mark.taylor@dummy.com" });
            modelBuilder.Entity<EmployeeDetail>().HasData(new EmployeeDetail { Id = 3, FirstName = "Nick", LastName = "Jonas", Email = "nick.jonas@dummy.com" });
        }
    }
}