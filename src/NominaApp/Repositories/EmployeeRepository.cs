using System.Collections.Generic;
using NominaApp.Interfaces;
using NominaApp.Models;

namespace NominaApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> Employees { get; }
        public EmployeeRepository()
        {
            Employees = new List<Employee>()
            {
                new Employee(1, "Junior", "Gervacio", "Team Leader Manager", 50_000.00),
                new Employee(2, "Roberto", "Pastoriza", "DBA", 13_482.00),
                new Employee(3, "Wiston", "Churchill", "Backend Developer", 60_000.00),
                new Employee(4, "Jimenez", "Moya", "Frontend Developer", 21_000.00),
                new Employee(5, "Romulo", "Betancourt", "Fullstack Developer", 65_000.00)
            };
        }

        public List<Employee> GetEmployees()
        {
            return Employees;
        }
    }
}