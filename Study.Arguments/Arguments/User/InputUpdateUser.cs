using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputUpdateUser : BaseInputUpdate<InputUpdateUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
