using GraphQLTestApi.Models;
using GraphQLTestApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLTestApi.GraphQLContext
{
    public class Query
    {
        private readonly IEmployeeService empployeeService;
        private readonly IDepartmentService departmentService;

        public Query(IEmployeeService empployeeService, IDepartmentService departmentService)
        {
            this.empployeeService = empployeeService;
            this.departmentService = departmentService;
        }

        public IQueryable<Employee> Empleados => empployeeService.GetAll();
        public List<Department> Departments => departmentService.GetAllDepartmentOnly();
        public List<Department> DepartmentsWithEmployee => departmentService.GetAllDepartmentsWithEmployee();


    }
}
