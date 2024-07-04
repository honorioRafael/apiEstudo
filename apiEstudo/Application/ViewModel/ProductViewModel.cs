using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel
{
    public class ProductViewModel : BaseViewModel<Product>, IProductViewModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
