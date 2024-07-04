using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.DTOs
{
    public class EmployeeDTO : IBaseDTO<EmployeeDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public EmployeeTaskDTO EmployeeTask { get; set; }

        public static implicit operator Employee(EmployeeDTO dto)
        {            
            return Employee.FromDTO(dto);
        }
    }

    public class EmployeeDTOSimplified
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
