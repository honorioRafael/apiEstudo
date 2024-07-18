using Study.Domain.DTO;
using Study.Infrastructure.Entry.Base;

namespace Study.Infrastructure.Entry
{
    public class EmployeeTask : BaseEntry<EmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public EmployeeTask(string name, string description)
        {
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
        }

        public EmployeeTask() { }

        public static implicit operator EmployeeTaskDTO(EmployeeTask employeeTask)
        {
            return employeeTask == null ? default : new EmployeeTaskDTO().Create(
                employeeTask.Id,
                new EmployeeTaskExternalPropertiesDTO(employeeTask.Name, employeeTask.Description),
                new EmployeeTaskInternalPropertiesDTO().LoadInternalData(employeeTask.Id, employeeTask.CreationDate, employeeTask.ChangeDate));
        }

        public static implicit operator EmployeeTask(EmployeeTaskDTO dto)
        {
            return dto == null ? default : new EmployeeTask(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Description).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
