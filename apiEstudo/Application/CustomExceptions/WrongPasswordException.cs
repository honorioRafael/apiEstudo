namespace apiEstudo.Application
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message)
        { }
    }
}
