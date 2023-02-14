using AF_EF.Models;
using EFCore_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public async Task<int> Save()
        {
            return await SaveChangesAsync();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<StateMaster> StateMasters { get; set; }
    }
}
