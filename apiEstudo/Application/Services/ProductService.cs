using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace apiEstudo.Application.Services
{
    public class ProductService : BaseService<Product, ProductDTO>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository contextInterface) : base(contextInterface)
        {
            _productRepository = contextInterface;
        }

        public bool Create(ProductViewModel viewModel)
        {
            if (viewModel == null) return false;

            var Entity = new Product(viewModel);
            _productRepository.Create(Entity);
            return true;
        }

        public bool Update(int id, ProductViewModel view)
        {
            if (view == null) return false;
            Product item = _productRepository.Get(id);
            if (item == null) return false;

            item.Name = view.Name;
            item.Quantity = view.Quantity;
            item.BrandId = view.BrandId;

            _productRepository.Update(item);
            return true;
        }
    }
}
