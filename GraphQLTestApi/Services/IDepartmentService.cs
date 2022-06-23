using GraphQLTestApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLTestApi.Services
{
    public interface IDepartmentService
    {
        Task<Department> CreateDepartment(Department department);
        List<Department> GetAllDepartmentOnly();
        List<Department> GetAllDepartmentsWithEmployee();
    }
}
