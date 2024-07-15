using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ProductService : BaseService_2<Product, IProductRepository, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>, IProductService
    {
        public ProductService(IProductRepository contextInterface, IBrandRepository brandRepository) : base(contextInterface)
        {
            _brandRepository = brandRepository;
        }
        private readonly IBrandRepository _brandRepository;

        public override List<long> CreateMultiple(List<InputCreateProduct> listInputCreate)
        {
            if (listInputCreate.Count == 0)
                throw new ArgumentNullException();
            List<Brand>? listRelatedBrands = _brandRepository.GetListByListId((from i in listInputCreate select i.BrandId).ToList());
            if (listRelatedBrands == null || listRelatedBrands.Count == 0)                
                throw new NotFoundException("ID da marca não localizado.");
            if (listInputCreate.Any(x => x.Quantity < 0))
                throw new InvalidArgumentException("Quantidade inválida!");

            var productsToCreate = InternalCreate(listInputCreate);
            return _repository.CreateMultiple(productsToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct)
        {
            List<Brand>? listRelatedBrands = _brandRepository.GetListByListId((from i in listInputIdentityUpdateProduct select i.InputUpdate.BrandId).ToList());
            if (listRelatedBrands == null || listRelatedBrands.Count == 0)
                throw new NotFoundException("ID da marca não localizado.");

            if (listInputIdentityUpdateProduct.Any(x => x.InputUpdate.Quantity < 0))
                throw new InvalidArgumentException("Quantidade inválida!");

            List<Product> ProductsToBeUpdated = GetListByListId((from i in listInputIdentityUpdateProduct select i.Id).ToList());
            if (ProductsToBeUpdated.Count == 0)
                throw new NotFoundException("Product ID não localizado!");

            var productsToUpdate = InternalUpdate(listInputIdentityUpdateProduct, ProductsToBeUpdated);
            return _repository.UpdateMultiple(productsToUpdate);
        }
    }
}
