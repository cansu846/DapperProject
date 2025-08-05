namespace DapperProject.Dtos.EmployeeDtos
{
    public class ResultEmployeeWithDepartmentDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }
}
