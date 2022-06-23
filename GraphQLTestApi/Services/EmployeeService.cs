using GraphQLTestApi.Context;
using GraphQLTestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Employee> Create(Employee employee)
        {
            var data = new Employee
            {
                Name = employee.Name,
                Designation = employee.Designation,
                Age = employee.Age, 
                Email = employee.Email,
                DepartmentId = employee.DepartmentId                

            };

            await _context.Employees.AddAsync(data);
            await _context.SaveChangesAsync();


            data.Department = await _context.Departments.FirstAsync( x => x.DepartmentId == data.DepartmentId);
            return data;
        }

        public async Task<bool> Delete(int EmployeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeId);

            if(employee is not null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public IQueryable<Employee> GetAll()
        {
            return  _context.Employees.AsQueryable();
        }

    }
}
