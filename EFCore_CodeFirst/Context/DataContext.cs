using AF_EF.Models;
using EFCore_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=L201412;Initial Catalog=Pratice;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PostgreSQL
            //modelBuilder.HasDefaultSchema("public");
            //modelBuilder.Entity<Employee>().ToTable("Employee");
            //base.OnModelCreating(modelBuilder);

            //SQL
           // modelBuilder.Entity<StateMaster>().ToTable("StateMaster");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
    }
}
