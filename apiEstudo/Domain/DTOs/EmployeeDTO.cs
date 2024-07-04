namespace apiEstudo.Domain.DTOs
{
    public class EmployeeDTO : IBaseDTO<EmployeeDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public EmployeeTaskDTO EmployeeTask { get; set; }
    }

    public class EmployeeDTOSimplified
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
