using DapperProject.Dtos.DepartmentDtos;

namespace DapperProject.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id);
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(int id);
    }
}
