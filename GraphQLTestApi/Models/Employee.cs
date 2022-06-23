using System.ComponentModel.DataAnnotations;

namespace GraphQLTestApi.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="You should enter a name")]
        public string Name { get; set; }
        public string Designation { get; set; }

        [EmailAddress]
        public string Email
        {
            get;
            set;
        }

        [Range(minimum: 20, maximum: 50)]
        public int Age
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public Department Department
        {
            get;
            set;
        }
    }
}
