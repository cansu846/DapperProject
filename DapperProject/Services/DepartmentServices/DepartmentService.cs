using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.DepartmentDtos;

namespace DapperProject.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DapperContext _dapperContext;

        public DepartmentService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            string query = "insert into TblDepartment (DepartmentName) values (@p1)";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", createDepartmentDto.DepartmentName);
            var conn = _dapperContext.CreateConnection();
           await conn.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            string query = "delete from TblDepartment where DepartmentId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            var conn = _dapperContext.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultDepartmentDto>> GetAllDepartmentAsync()
        {
            string query = "select * from TblDepartment";
            var conn = _dapperContext.CreateConnection();
            var values = await conn.QueryAsync<ResultDepartmentDto>(query);
            return values.ToList();
        }

        public async Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id)
        {
            string query = "select * from TblDepartment where DepartmentId==@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id",id);
            var conn = _dapperContext.CreateConnection();
            var values = await conn.QueryFirstAsync<GetDepartmentByIdDto>(query);
            return values;
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "update TblDepartment set DepartmentName=@departmentName where DepartmentId==@departmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@departmentName",updateDepartmentDto.DepartmentName);
            parameters.Add("@departmentId",updateDepartmentDto.DepartmentId);
            var conn = _dapperContext.CreateConnection();   
            await conn.ExecuteAsync(query, parameters);
        }
    }
}
