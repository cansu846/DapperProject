using DapperProject.Dtos.DepartmentDtos;
using DapperProject.Services.DepartmentServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<IActionResult> DepartmentList()
        {
            var values = await _departmentService.GetAllDepartmentAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDepartment() {
            return View();  
        }

        [HttpPost]  
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return RedirectToAction("DepartmentList");
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("DepartmentList");
        }


        [HttpGet]
        public IActionResult UpdateDepartment(int id)
        {
            var value = _departmentService.GetDepartmentByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentDto);
            return RedirectToAction("DepartmentList");
        }
    }
}
