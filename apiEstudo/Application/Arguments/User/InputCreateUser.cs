using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateUser : BaseInputCreate<InputCreateUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
