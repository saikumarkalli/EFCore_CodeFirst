using AF_EF.Models;

namespace EFCore_CodeFirst.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetData();
        Task<Employee?> GetDataById(int id);
        Task<bool> InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}
