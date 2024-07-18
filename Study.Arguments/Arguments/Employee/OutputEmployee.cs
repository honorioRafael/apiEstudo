using apiEstudo.Domain.DTOs;

namespace apiEstudo.Application.Arguments
{
    public class OutputEmployee : BaseOutput<OutputEmployee>
    {
        public string Name { get; set; }
        public long EmployeeTaskId { get; set; }
        public int Age { get; set; }
        public OutputEmployeeTask EmployeeTask { get; set; }

        public OutputEmployee()
        { }

        public OutputEmployee(string name, long employeeTaskId, int age, EmployeeTaskDTO task)
        {
            Name = name;
            EmployeeTaskId = employeeTaskId;
            Age = age;

            EmployeeTask = (OutputEmployeeTask)task;
        }
    }
}
