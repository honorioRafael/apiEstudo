using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class EmployeeDTO : BaseDTO<InputCreateEmployee, InputUpdateEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>
    {
        public EmployeeDTO() { }

        public static implicit operator OutputEmployee(EmployeeDTO dto)
        {
            return dto == null ? default : new OutputEmployee(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.EmployeeTaskId, dto.ExternalPropertiesDTO.Age, dto.AuxiliaryPropertiesDTO.EmployeeTaskDTO).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator EmployeeDTO(OutputEmployee output)
        {
            return output == null ? default : new EmployeeDTO().Create(output.Id,
                new EmployeeExternalPropertiesDTO(output.Name, output.Age, output.EmployeeTaskId),
                new EmployeeInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate),
                new EmployeeAuxiliaryPropertiesDTO(output.EmployeeTask));
        }
    }
}
