using EFCore_CodeFirst.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using AF_EF.Models;
using Microsoft.Data.SqlClient;

namespace EFCore_CodeFirst.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        //DataContext dataContext = new DataContext();
        DataContext _dataContext;

        public EmployeeService(DataContext dataContext)
        {
            //Injecting connection string to Dbcontext 
            //var options = DbContextHelper.GetDbContextOptions();
            //_dataContext = new DataContext(options);
            _dataContext = dataContext;
        }

        public async Task<List<Employee>> GetData()
        {
            List<Employee> data = await _dataContext.Employees.ToListAsync<Employee>();
            return data;
        }

        //Get Data by id
        public async Task<Employee?> GetDataById(int id)
        {
            Employee? data = null;
            if (id != 0)
            {
                data = await _dataContext.Employees.Where(x => x.id == id).FirstOrDefaultAsync<Employee>();

                return data;
            }
            else
            {
                return data = null;
            }
        }

        public async Task<bool> InsertEmployee(Employee employee)
        {
            if (employee != null)
            {
                await _dataContext.Employees.AddAsync(employee);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                var empRecord = _dataContext.Employees.Where(x => x.id == employee.id).FirstOrDefault();

                if (empRecord != null)
                {
                    empRecord.empname = employee.empname;
                    empRecord.emailid = employee.emailid;
                    empRecord.phonenumber = employee.phonenumber;

                    _dataContext.Employees.Update(empRecord);
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            if (id != 0)
            {
                var empRecord = _dataContext.Employees.Where(x => x.id == id).FirstOrDefault();

                if (empRecord != null)
                {
                    _dataContext.Employees.Remove(empRecord);
                    await _dataContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
