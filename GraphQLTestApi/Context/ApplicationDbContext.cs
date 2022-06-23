using GraphQLTestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTestApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
               new Department
               {
                   DepartmentId = 1,
                   Name = "TI"
               },
               new Department
               {
                   DepartmentId = 2,
                   Name = "Accounting"
               },
               new Department
               {
                   DepartmentId = 3,
                   Name = "RRHH"
               }
            );



            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Barry Allen",
                    DepartmentId = 1,   
                },
                new Employee
                {
                    Id = 2,
                    Name = "Hal Jordan",
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 3,
                    Name = "Wally West",
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 4,
                    Name = "Donna Trhoy",
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 5,
                    Name = "Bart Allen",
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 6,
                    Name = "Oliver Queen",
                    DepartmentId = 1
                }
            );
        }
    }
}
