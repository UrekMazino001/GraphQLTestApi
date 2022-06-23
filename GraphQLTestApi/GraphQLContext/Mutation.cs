using GraphQLTestApi.Models;
using GraphQLTestApi.Services;
using System.Threading.Tasks;

namespace GraphQLTestApi.GraphQLContext
{
    public class Mutation
    {
        private readonly IEmployeeService employeeService;

        public Mutation(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<Employee> Create(Employee employee) => await employeeService.Create(employee);
        public async Task<bool> Delete(int employeeId) => await employeeService.Delete(employeeId);

    }
}
