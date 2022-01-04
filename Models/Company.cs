using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_csharp_winform.Models
{
    public class Company
    {
        // The company name
        public string Name { get; set; }
        // The list of company employees
        public ICollection<Employee> Employees { get; set; }

        public Company()
        {

        }
        // Primary constructor for Company object
        public Company(string name)
        {
            this.Name = name;
            Employees = new List<Employee>();

            Employees.Add(new Employee() { Name = "John Doe", Department = "HR", DOB = new DateTime(1987, 01, 16) });
            Employees.Add(new Employee() { Name = "Jane Doe", Department = "ITS", DOB = new DateTime(1992, 05, 16) });
        }

    } 
}
