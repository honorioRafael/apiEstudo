using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateEmployee : BaseInputCreate<InputCreateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int TaskId { get; set; }
    }
}
