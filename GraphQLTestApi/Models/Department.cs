﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQLTestApi.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public ICollection<Employee> Employees
        {
            get;
            set;
        }
    }
}
