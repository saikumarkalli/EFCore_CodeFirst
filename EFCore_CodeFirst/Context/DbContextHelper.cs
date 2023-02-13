using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst.Context
{
    public static class DbContextHelper
    {
        private const string _connectionString = "Data Source=L201412;Initial Catalog=Pratice;Integrated Security=True;TrustServerCertificate=True";



        public static DbContextOptions<DataContext> GetDbContextOptions()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseSqlServer(new SqlConnection(_connectionString)).Options;

            return options;
        }

    }

}
