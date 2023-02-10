using EFCore_CodeFirst.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using AF_EF.Models;

namespace EFCore_CodeFirst.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        DataContext dataContext = new DataContext();

        public async Task<List<Employee>> GetData()
        {
            List<Employee> data = await dataContext.Employees.ToListAsync<Employee>();
            return data;
        }

        //Get Data by id
        public async Task<Employee?> GetDataById(int id)
        {
            Employee? data = null;
            if (id != 0)
            {
                data = await dataContext.Employees.Where(x => x.id == id).FirstOrDefaultAsync<Employee>();

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
                await dataContext.Employees.AddAsync(employee);
                await dataContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                var empRecord = dataContext.Employees.Where(x => x.id == employee.id).FirstOrDefault();

                if (empRecord != null)
                {
                    empRecord.empname = employee.empname;
                    empRecord.emailid = employee.emailid;
                    empRecord.phonenumber = employee.phonenumber;

                    dataContext.Employees.Update(empRecord);
                    await dataContext.SaveChangesAsync();
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
                var empRecord = dataContext.Employees.Where(x => x.id == id).FirstOrDefault();

                if (empRecord != null)
                {
                    dataContext.Employees.Remove(empRecord);
                    await dataContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
