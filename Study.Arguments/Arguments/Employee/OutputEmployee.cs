using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class OutputEmployee : BaseOutput<OutputEmployee>
    {
        public string Name { get; set; }
        public long EmployeeTaskId { get; set; }
        public int Age { get; set; }
        public OutputEmployeeTask EmployeeTask { get; set; }

        public OutputEmployee()
        { }

        public OutputEmployee(string name, long employeeTaskId, int age, OutputEmployeeTask task)
        {
            Name = name;
            EmployeeTaskId = employeeTaskId;
            Age = age;
            EmployeeTask = task;
        }
    }
}
