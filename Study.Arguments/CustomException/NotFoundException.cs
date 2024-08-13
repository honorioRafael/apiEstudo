namespace Study.Arguments.CustomException
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Id não localizado") : base(message) { }
    }
}