using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateEmployeeTask : BaseInputCreate<InputCreateEmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
