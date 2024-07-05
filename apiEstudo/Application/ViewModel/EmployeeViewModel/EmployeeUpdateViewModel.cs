using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IEmployeeViewModel;
using apiEstudo.Domain.Model;

namespace apiEstudo.Application.ViewModel.EmployeeViewModel
{
    public class EmployeeUpdateViewModel : BaseUpdateViewModel<Employee>, IEmployeeUpdateViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int taskId { get; set; }
    }
}
