namespace Study.Domain.DTO
{
    public class EmployeeExternalPropertiesDTO : BaseExternalPropertiesDTO<EmployeeExternalPropertiesDTO>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long EmployeeTaskId { get; set; }

        public EmployeeExternalPropertiesDTO() { }

        public EmployeeExternalPropertiesDTO(string name, int age, long employeeTaskId)
        {
            Name = name;
            Age = age;
            EmployeeTaskId = employeeTaskId;
        }
    }
}
