namespace apiEstudo.Domain.DTOs
{
    public class EmployeeTaskExternalPropertiesDTO : BaseExternalPropertiesDTO<EmployeeTaskExternalPropertiesDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EmployeeTaskExternalPropertiesDTO() { }

        public EmployeeTaskExternalPropertiesDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
