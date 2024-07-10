using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ProductService : BaseService<Product, IProductRepository, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>, IProductService
    {
        public ProductService(IProductRepository contextInterface, IBrandRepository brandRepository) : base(contextInterface)
        {
            _brandRepository = brandRepository;
        }
        private readonly IBrandRepository _brandRepository;

        public override long Create(InputCreateProduct inputCreateProduct)
        {
            if (inputCreateProduct == null) 
                throw new ArgumentNullException();
            if (_brandRepository.Get(inputCreateProduct.BrandId) == null)
                throw new NotFoundException("ID da marca não localizado.");
            if (inputCreateProduct.Quantity < 0)
                throw new InvalidArgumentException("Quantidade inválida!");

            return _repository.Create(new Product(inputCreateProduct.Name, inputCreateProduct.Quantity, inputCreateProduct.BrandId, null).SetCreationDate());
        }

        public override long Update(InputIdentityUpdateProduct inputIdentityUpdate)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdate.Id);
            if (OriginalItem == null) throw new NotFoundException();
            if (_brandRepository.Get(inputIdentityUpdate.InputUpdate.BrandId) == null)
                throw new NotFoundException("ID da marca não localizado.");
            if (inputIdentityUpdate.InputUpdate.Quantity < 0)
                throw new InvalidArgumentException("Quantidade inválida!");

            return _repository.Update(new Product(inputIdentityUpdate.InputUpdate.Name,
                inputIdentityUpdate.InputUpdate.Quantity,
                inputIdentityUpdate.InputUpdate.BrandId, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }
}
