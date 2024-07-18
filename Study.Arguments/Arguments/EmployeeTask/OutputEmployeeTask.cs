using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class OutputEmployeeTask : BaseOutput<OutputEmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public OutputEmployeeTask()
        { }

        public OutputEmployeeTask(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
