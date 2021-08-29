using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NominaApp.Interfaces;
using NominaApp.Models;

namespace MyApp.Namespace
{
    public class NominaModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public List<Employee> Employees;
        public NominaModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
            Employees = _employeeRepository.GetEmployees();
        }
    }
}
