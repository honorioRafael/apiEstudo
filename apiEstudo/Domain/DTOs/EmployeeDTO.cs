namespace apiEstudo.Domain.DTOs
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public EmployeeTaskDTO? EmployeeTask { get; set; }
    }
}
