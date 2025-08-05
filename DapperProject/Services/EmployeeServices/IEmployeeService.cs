using DapperProject.Dtos.EmployeeDtos;

namespace DapperProject.Services.EmployeeServices
{
    public interface IEmployeeService
    {
        Task<List<ResultEmployeeDto>> GetAllEmployeeAsync(); 
        Task<List<ResultEmployeeWithDepartmentDto>> GetAllEmployeeWithDepartmentAsync(); 
        Task<GetEmployeeByIdDto> GetEmployeeByIdAsync(int id); 
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployeeAsync(int id); 
    }
}
