using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputUpdateEmployeeTask : BaseInputUpdate<InputUpdateEmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
