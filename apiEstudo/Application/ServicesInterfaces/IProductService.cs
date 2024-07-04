using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IProductService : IBaseService<Product, ProductDTO>
    {
        public bool Create(ProductViewModel viewModel);
        public bool Update(int id, ProductViewModel viewModel);
    }
}
