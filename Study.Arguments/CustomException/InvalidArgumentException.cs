namespace Study.Arguments.CustomException
{
    public class InvalidArgumentException : Exception
    {
        public InvalidArgumentException(string message) : base(message) { }
    }
}