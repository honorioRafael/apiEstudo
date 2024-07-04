using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class EmployeeTask : BaseEntry<EmployeeTask>, IBaseModel<EmployeeTask>
    {
        public string Name { get; set; }        
        public string Description { get; set; }
        

        public EmployeeTask(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public static implicit operator EmployeeTaskDTO(EmployeeTask employeeTask)
        {
            return employeeTask == null ? default : new EmployeeTaskDTO { Name = employeeTask.Name, Description = employeeTask.Description };
        }
    }
}
