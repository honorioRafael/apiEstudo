namespace apiEstudo.Application
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Id não localizado") : base(message)
        {
        }
    }
}
