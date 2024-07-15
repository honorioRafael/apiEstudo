using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
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

        public override List<int> CreateMultiple(List<InputCreateProduct> listInputCreate)
        {
            if (listInputCreate.Count == 0)
                throw new ArgumentNullException();
            if (listInputCreate.Any(x => _brandRepository.Get(x.BrandId) == null))
                throw new NotFoundException("ID da marca não localizado.");
            if (listInputCreate.Any(x => x.Quantity < 0))
                throw new InvalidArgumentException("Quantidade inválida!");

            var productsToCreate = InternalCreate(listInputCreate);
            return _repository.CreateMultiple(productsToCreate);// _repository.Create(new Product(inputCreateProduct.Name, inputCreateProduct.Quantity, inputCreateProduct.BrandId, null).SetCreationDate());
        }

        public int Update(InputIdentityUpdateProduct inputIdentityUpdate)
        {          
            if (_brandRepository.Get(inputIdentityUpdate.InputUpdate.BrandId) == null)
                throw new NotFoundException("ID da marca não localizado.");
            if (inputIdentityUpdate.InputUpdate.Quantity < 0)
                throw new InvalidArgumentException("Quantidade inválida!");

            return base.Update(inputIdentityUpdate);// _repository.Update(new Product(inputIdentityUpdate.InputUpdate.Name,
                //inputIdentityUpdate.InputUpdate.Quantity,
                //inputIdentityUpdate.InputUpdate.BrandId, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }
}
