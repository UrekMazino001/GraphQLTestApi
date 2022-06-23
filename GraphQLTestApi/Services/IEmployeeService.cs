using GraphQLTestApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTestApi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Create(Employee employee);
        Task<bool> Delete(int EmployeeId);
        IQueryable<Employee> GetAll();
    }
}
