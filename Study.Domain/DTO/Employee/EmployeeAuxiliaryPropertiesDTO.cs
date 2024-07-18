namespace Study.Domain.DTO
{
    public class EmployeeAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<EmployeeAuxiliaryPropertiesDTO>
    {
        public EmployeeTaskDTO EmployeeTaskDTO { get; set; }
        public EmployeeAuxiliaryPropertiesDTO() { }

        public EmployeeAuxiliaryPropertiesDTO(EmployeeTaskDTO employeeTask)
        {
            EmployeeTaskDTO = employeeTask;
        }
    }
}
