namespace apiEstudo.Application
{
    public class NameInUseException : Exception
    {
        public NameInUseException(string message) : base(message)
        { }
    }
}
