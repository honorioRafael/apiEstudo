using Study.Domain.DTO;
using Study.Infrastructure.Entry.Base;

namespace Study.Infrastructure.Entry
{
    /*
        Table para indicar o nome da tabela. Caso na tabela esteja diferente da classe, inserir o da tabela entre ""
     */
    //[Table("Employee")
    public class Employee : BaseEntry<Employee>
    {
        #region Properties
        public string? Name { get; set; }
        public int Age { get; set; }
        public long EmployeeTaskId { get; set; }

        #region Internal
        public EmployeeTask EmployeeTask { get; set; }

        #endregion

        #region External
        public virtual List<Shopping> Shoppings { get; set; }

        #endregion
        #endregion

        public Employee(string? name, int age, long employeeTaskId, EmployeeTask employeeTask)
        {
            Name = name;
            Age = age;
            EmployeeTaskId = employeeTaskId;
            EmployeeTask = employeeTask;
        }

        public Employee()
        { }

        public static implicit operator EmployeeDTO(Employee employee)
        {
            return employee == null ? default : new EmployeeDTO().Create(
                employee.Id,
                new EmployeeExternalPropertiesDTO(employee.Name, employee.Age, employee.EmployeeTaskId),
                new EmployeeInternalPropertiesDTO().LoadInternalData(employee.Id, employee.CreationDate, employee.ChangeDate),
                new EmployeeAuxiliaryPropertiesDTO(employee.EmployeeTask));
        }

        public static implicit operator Employee(EmployeeDTO dto)
        {
            return dto == null ? default : new Employee(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Age, dto.ExternalPropertiesDTO.EmployeeTaskId, dto.AuxiliaryPropertiesDTO.EmployeeTaskDTO)
                .LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
