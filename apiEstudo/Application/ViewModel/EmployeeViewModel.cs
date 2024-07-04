using apiEstudo.Domain.Model;

namespace apiEstudo.Application.ViewModel
{
    public class EmployeeViewModel : BaseViewModel<EmployeeViewModel>, IEmployeeViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int taskId { get; set; }
    }

    public interface IEmployeeViewModel : IBaseViewModel
    {
        //public string Name { get; set; }
        //public int Age { get; set; }
        //public int taskId { get; set; }
    }
}
