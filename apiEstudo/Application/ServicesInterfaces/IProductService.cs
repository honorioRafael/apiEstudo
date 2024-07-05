using apiEstudo.Application.ViewModel.ProductViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IProductService : IBaseService<Product, ProductDTO>
    {
        public bool Create(ProductCreateViewModel viewModel);
        public bool Update(int id, ProductCreateViewModel viewModel);
    }
}
