using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IBrandViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.BrandViewModel
{
    public class BrandCreateViewModel : BaseCreateViewModel<Brand>, IBrandCreateViewModel
    {
        public string Name { get; set; }
    }
}
