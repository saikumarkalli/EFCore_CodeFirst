using AF_EF.Models;
using EFCore_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst.Context
{
    public interface IDataContext
    {
        Task<int> Save();
        DbSet<Employee> Employees { get; set; }
        DbSet<StateMaster> StateMasters { get; set; }
    }
}
