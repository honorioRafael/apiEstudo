using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IEmployeeTaskViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.EmployeeTaskViewModel
{
    public class EmployeeTaskCreateViewModel : BaseCreateViewModel<EmployeeTask>, IEmployeeTaskCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
