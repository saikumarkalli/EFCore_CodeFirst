using EFCore_CodeFirst.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using AF_EF.Models;
using Microsoft.Data.SqlClient;

namespace EFCore_CodeFirst.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        IDataContext _dbContext;

        public EmployeeService(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetData()
        {
            List<Employee> data = await _dbContext.Employees.ToListAsync<Employee>();
            return data;
        }

        //Get Data by id
        public async Task<Employee?> GetDataById(int id)
        {
            Employee? data = null;
            if (id != 0)
            {
                data = await _dbContext.Employees.Where(x => x.id == id).FirstOrDefaultAsync<Employee>();

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
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.Save();
                return true;
            }
            else return false;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                var empRecord = _dbContext.Employees.Where(x => x.id == employee.id).FirstOrDefault();

                if (empRecord != null)
                {
                    empRecord.empname = employee.empname;
                    empRecord.emailid = employee.emailid;
                    empRecord.phonenumber = employee.phonenumber;

                    _dbContext.Employees.Update(empRecord);
                    await _dbContext.Save();
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
                var empRecord = _dbContext.Employees.Where(x => x.id == id).FirstOrDefault();

                if (empRecord != null)
                {
                    _dbContext.Employees.Remove(empRecord);
                    await _dbContext.Save();
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
