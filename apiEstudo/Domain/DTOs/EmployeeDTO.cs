namespace apiEstudo.Domain.DTOs
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string? name { get; set; }
        public TaskDTO? task { get; set; }
        //public string taskName { get; set; }
        //public int age { get; private set; }
    }
}
