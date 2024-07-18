namespace Study.Arguments.CustomException
{
    public class NameInUseException : Exception
    {
        public NameInUseException(string message) : base(message) { }
    }
}