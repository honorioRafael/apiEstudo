namespace Study.Arguments.Arguments
{
    public class OutputUser : BaseOutput<OutputUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public OutputUser()
        { }

        public OutputUser(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
