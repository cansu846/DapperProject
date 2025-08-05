using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DapperContext _context;

        public EmployeeService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into TblEmployee (Name, Surname, Salary) values (@name,@surname,@salary)";

            var parameters = new DynamicParameters();

            parameters.Add("@name",createEmployeeDto.Name);
            parameters.Add("@surname",createEmployeeDto.Surname);
            parameters.Add("@salary",createEmployeeDto.Salary);
            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);  
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "Delete from TblEmployee where EmployeeId=@p1";
            var parameters = new DynamicParameters();
            parameters.Add("@p1",id);
            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * from TblEmployee";
            var conn = _context.CreateConnection();
            var values = await conn.QueryAsync<ResultEmployeeDto>(query); 
            //ef metodu olan tolist metodundan farklı
            return values.ToList();
        }

        [HttpGet("GetAllEmployeeWithDepartment")]
        public async Task<List<ResultEmployeeWithDepartmentDto>> GetAllEmployeeWithDepartmentAsync()
        {
            string query = "Select * from TblEmployee inner join TblDepartment on TblEmployee.DepartmentId=TblDepartment.DepartmentId";
            var conn = _context.CreateConnection();
            var values = await conn.QueryAsync<ResultEmployeeWithDepartmentDto>(query);
            //ef metodu olan tolist metodundan farklı
            return values.ToList();
        }

        public async Task<GetEmployeeByIdDto> GetEmployeeByIdAsync(int id )
        {
            string query = "Select * from TblEmployee where EmployeeId=@id";
            var parameters =new DynamicParameters();
            parameters.Add("@id",id);
            var conn = _context.CreateConnection();
            var values = await conn.QueryFirstOrDefaultAsync<GetEmployeeByIdDto>(query,parameters);
            return values;
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "update TblEmployee set Name=@name, Surname=@surname, Salary=@salary where EmployeeId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name",updateEmployeeDto.Name);
            parameters.Add("@surname",updateEmployeeDto.Surname);
            parameters.Add("@salary",updateEmployeeDto.Salary);
            parameters.Add("@id",updateEmployeeDto.EmpoyeeId);
            var conn = _context.CreateConnection();
            await conn.ExecuteAsync(query, parameters);
        }
    }
}
