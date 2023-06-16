using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class EmployeeBook1
    {
        private List<Employee> employees;

        public EmployeeBook1()
        {
            employees = new List<Employee>();
        }
        public void AddEmployee(string fullName, int id, decimal salary, string department)
        {
            Employee employee = new Employee
            {
                FullName = fullName,
                ID = id,
                Salary = salary,
                Department = department
            };

            employees.Add(employee);
        }

        public void RemoveEmployee(string fullNameOrId)
        {
            Employee employee = FindEmployee(fullNameOrId);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        public void UpdateSalary(string fullName, decimal newSalary)
        {
            Employee employee = FindEmployee(fullName);
            if (employee != null)
            {
                employee.Salary = newSalary;
            }
        }

        public void UpdateDepartment(string fullName, string newDepartment)
        {
            Employee employee = FindEmployee(fullName);
            if (employee != null)
            {
                employee.Department = newDepartment;
            }
        }

        public void PrintEmployeesByDepartments()
        {
            Dictionary<string, List<string>> departmentEmployees = new Dictionary<string, List<string>>();

            foreach (Employee employee in employees)
            {
                if (departmentEmployees.ContainsKey(employee.Department))
                {
                    departmentEmployees[employee.Department].Add(employee.FullName);
                }
                else
                {
                    departmentEmployees[employee.Department] = new List<string> { employee.FullName };
                }
            }

            foreach (var department in departmentEmployees)
            {
                Console.WriteLine($"Department: {department.Key}");
                foreach (string employee in department.Value)
                {
                    Console.WriteLine(employee);
                }
                Console.WriteLine();
            }
        }

        private Employee FindEmployee(string fullNameOrId)
        {
            return employees.Find(e => e.FullName == fullNameOrId || e.ID.ToString() == fullNameOrId);
        }
    }
}
