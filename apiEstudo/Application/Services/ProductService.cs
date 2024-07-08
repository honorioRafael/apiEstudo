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
        public ProductService(IProductRepository contextInterface) : base(contextInterface)
        { }

        public override long Create(InputCreateProduct inputCreate)
        {
            if (inputCreate == null) throw new ArgumentNullException();
            return _repository.Create(new Product(inputCreate.Name, inputCreate.Quantity, inputCreate.BrandId, null).SetCreationDate());
        }

        public override long Update(InputIdentityUpdateProduct inputIdentityUpdate)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdate.Id);
            if (OriginalItem == null) throw new NotFoundException();
            return _repository.Update(new Product(inputIdentityUpdate.InputUpdate.Name,
                inputIdentityUpdate.InputUpdate.Quantity,
                inputIdentityUpdate.InputUpdate.BrandId, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }
}
