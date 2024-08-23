using CheckPoint.Interfaces;
using CheckPoint.Models;
using System;

namespace CheckPoint.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        public EmployeeService()
        {
            using (var context = new CheckPointDBContext())
            {
                var employees = new List<Employee>
                {               
                new Employee
                {
                    FirstName ="Dan",
                    LastName ="Lee",
                },
                new Employee
                {
                    FirstName ="Lena",
                    LastName ="Granenkina",
                },
                 new Employee
                {
                    FirstName ="Tatyana",
                    LastName ="Kim",
                },
                new Employee
                {
                    FirstName ="Aibek",
                    LastName ="Danabayev",
                },
                 new Employee
                {
                    FirstName ="Zhanat",
                    LastName ="Marat",
                },
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }

        public Employee GetById(int id)
        {
            using (var context = new CheckPointDBContext())
            {
                var employee = context.Employees.Find(id);
                return employee;
            }
        }

        public List<Employee> GetEmployees()
        {
            using (var context = new CheckPointDBContext())
            {
                var list = context.Employees.ToList();
                return list;
            }
        }
    }
}
