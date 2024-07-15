namespace apiEstudo.Application.Arguments
{
    public class InputUpdateEmployee : BaseInputUpdate<InputUpdateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long TaskId { get; set; }
    }
}
