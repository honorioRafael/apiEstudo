namespace Study.Arguments.CustomException
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message) { }
    }
}