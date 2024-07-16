namespace apiEstudo.Domain.DTOs
{
    public class EmployeeAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<EmployeeAuxiliaryPropertiesDTO>
    {
        public EmployeeTaskDTO EmployeeTask { get; set; }
        public EmployeeAuxiliaryPropertiesDTO() { }

        public EmployeeAuxiliaryPropertiesDTO(EmployeeTaskDTO employeeTask)
        {
            EmployeeTask = employeeTask;
        }
    }
}
