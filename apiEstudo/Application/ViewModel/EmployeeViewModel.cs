using apiEstudo.Domain.Model;

namespace apiEstudo.Application.ViewModel
{
    public class EmployeeViewModel : IBaseViewModel 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int taskId { get; set; }
    }
}
