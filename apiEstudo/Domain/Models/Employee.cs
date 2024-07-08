using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.Model
{
    /*
        Table para indicar o nome da tabela. Caso na tabela esteja diferente da classe, inserir o da tabela entre ""
     */
    //[Table("Employee")
    public class Employee : BaseEntry<Employee>
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public int EmployeeTaskId { get; set; }
        public EmployeeTask EmployeeTask { get; set; }
        public virtual ICollection<Shopping> Shoppings { get; set; }

        public Employee(string? name, int age, int employeeTaskId, EmployeeTask employeeTask)
        {
            Name = name;
            Age = age;
            EmployeeTaskId = employeeTaskId;
            EmployeeTask = employeeTask;
            CreationDate = DateTime.Now;
        }

        public Employee()
        { }

        public static implicit operator OutputEmployee(Employee employee)
        {
            return employee == null ? default : new OutputEmployee(employee.Name, employee.Age, employee.EmployeeTask).LoadInternalData(employee.Id, employee.CreationDate, employee.ChangeDate);
        }
    }
}
