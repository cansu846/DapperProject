using AspNetCoreGeneratedDocument;
using DapperProject.Dtos.EmployeeDtos;
using DapperProject.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DapperProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            //var values = await _employeeService.GetAllEmployeeAsync();
            var values = await _employeeService.GetAllEmployeeWithDepartmentAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateEmployeeAsync(createEmployeeDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var value = await _employeeService.GetEmployeeByIdAsync(id);
            UpdateEmployeeDto dto = new UpdateEmployeeDto
            {
                EmpoyeeId = id,
                Name = value.Name,
                Surname = value.Surname,
                Salary = value.Salary
            };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeService.UpdateEmployeeAsync(updateEmployeeDto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
