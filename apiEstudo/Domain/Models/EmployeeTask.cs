using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class EmployeeTask : BaseEntry<EmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public EmployeeTask(string name, string description)
        {
            Name = name;
            Description = description;
            CreationDate = DateTime.Now;
        }

        //public static implicit operator EmployeeTaskDTO(EmployeeTask employeeTask)
        //{
        //    return employeeTask == null ? default : new EmployeeTaskDTO { Name = employeeTask.Name, Description = employeeTask.Description };
        //}
    }
}
