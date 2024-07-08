using apiEstudo.Domain.Models;
using System.Threading.Tasks;

namespace apiEstudo.Application.Arguments
{
    public class OutputEmployee : BaseOutput<OutputEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public OutputEmployeeTask EmployeeTask { get; set; }

        public OutputEmployee()
        { }

        public OutputEmployee(string name, int age, EmployeeTask task)
        { 
            Name = name;
            Age = age;

            EmployeeTask = (OutputEmployeeTask)task;
        }
    }
}
