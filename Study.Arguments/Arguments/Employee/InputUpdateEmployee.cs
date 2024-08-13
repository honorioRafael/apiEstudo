using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputUpdateEmployee : BaseInputUpdate<InputUpdateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long EmployeeTaskId { get; set; }
    }
}
