using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.Model
{
    /*
        Table para indicar o nome da tabela. Caso na tabela esteja diferente da classe, inserir o da tabela entre ""
     */
    public class Employee : BaseEntry<Employee>
    {
        public string? Name { get; private set; }
        public int Age { get; private set; }
        public long EmployeeTaskId { get; private set; }
        public EmployeeTask? EmployeeTask { get; private set; }

        public Employee(string? name, int age, int employeeTaskId, EmployeeTask? employeeTask)
        {
            Name = name ?? throw new ArgumentNullException();
            Age = age;
            EmployeeTaskId = employeeTaskId;
            EmployeeTask = employeeTask;
        }

        public Employee()
        {
        }

        public static implicit operator EmployeeDTO(Employee employee)
        {
            return employee == null ? default : new EmployeeDTO { Id = employee.Id, Name = employee.Name, EmployeeTask = employee.EmployeeTask };
        }
    }

    public class BaseEntry<T> where T : BaseEntry<T>
    {
        public long Id { get; private set; }
    }
}
