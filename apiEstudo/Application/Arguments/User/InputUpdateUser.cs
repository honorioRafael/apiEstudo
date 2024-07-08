using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateUser : BaseInputUpdate<InputUpdateUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
