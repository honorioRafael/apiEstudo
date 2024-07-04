using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Model
{
    /*
        Table para indicar o nome da tabela. Caso na tabela esteja diferente da classe, inserir o da tabela entre ""
     */
    //[Table("Employee")
    public class Employee : BaseEntry<Employee>, IBaseModel<Employee>
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int EmployeeTaskId { get; set; }
        public EmployeeTask EmployeeTask { get; set; }

        public Employee(string? name, int age, int employeeTaskId)
        {
            Name = name ?? throw new ArgumentNullException();
            Age = age;
            EmployeeTaskId = employeeTaskId;
        }

        public Employee(string? name, int age, int employeeTaskId, EmployeeTask employeeTask)
        {
            Name = name ?? throw new ArgumentNullException();
            Age = age;
            EmployeeTaskId = employeeTaskId;
            EmployeeTask = employeeTask;
        }

        public Employee()
        { }

        public static implicit operator EmployeeDTOSimplified(Employee employee)
        {
            return employee == null ? default : new EmployeeDTOSimplified { Id = employee.Id, Name = employee.Name };
        }

        public static implicit operator EmployeeDTO(Employee employee)
        {
            return employee == null ? default : new EmployeeDTO { Id = employee.Id, Age = employee.Age, Name = employee.Name, EmployeeTask = employee.EmployeeTask };
        }
    }
}
