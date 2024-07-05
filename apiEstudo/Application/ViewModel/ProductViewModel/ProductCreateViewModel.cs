using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IProductViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.ProductViewModel
{
    public class ProductCreateViewModel : BaseCreateViewModel<Product>, IProductCreateViewModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
