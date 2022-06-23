using GraphQLTestApi.Context;
using GraphQLTestApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApi.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Department> GetAllDepartmentOnly()
        {
            return dbContext.Departments.ToList();
        }
        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return dbContext.Departments.Include(d => d.Employees).ToList();
        }
        public async Task<Department> CreateDepartment(Department department)
        {
            await dbContext.Departments.AddAsync(department);
            await dbContext.SaveChangesAsync();
            return department;
        }
    }
}
