using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
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

        public static implicit operator OutputEmployeeTask(EmployeeTask employeeTask)
        {
            return employeeTask == null ? default : new OutputEmployeeTask(employeeTask.Name, employeeTask.Description).LoadInternalData(employeeTask.Id, employeeTask.CreationDate, employeeTask.ChangeDate);
        }
    }
}
