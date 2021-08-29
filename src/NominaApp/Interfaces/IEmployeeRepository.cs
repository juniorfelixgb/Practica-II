using System.Collections.Generic;
using NominaApp.Models;

namespace NominaApp.Interfaces
{
    public interface IEmployeeRepository
    {
         public List<Employee> GetEmployees();
    }
}