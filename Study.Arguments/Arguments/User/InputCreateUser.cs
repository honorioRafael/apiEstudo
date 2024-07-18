namespace Study.Arguments.Arguments
{
    public class InputCreateUser : BaseInputCreate<InputCreateUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
