using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class EmployeeTaskDTO : BaseDTO<InputCreateEmployeeTask, InputUpdateEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>
    {
        public EmployeeTaskDTO() { }

        public static implicit operator OutputEmployeeTask(EmployeeTaskDTO dto)
        {
            return dto == null ? default : new OutputEmployeeTask(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Description).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator EmployeeTaskDTO(OutputEmployeeTask output)
        {
            return output == null ? default : new EmployeeTaskDTO().Create(output.Id,
                new EmployeeTaskExternalPropertiesDTO(output.Name, output.Description),
                new EmployeeTaskInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
