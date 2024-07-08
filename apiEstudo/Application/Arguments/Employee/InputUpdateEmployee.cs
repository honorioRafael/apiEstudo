using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateEmployee : BaseInputUpdate<InputUpdateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int TaskId { get; set; }
    }
}
