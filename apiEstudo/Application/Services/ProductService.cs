using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ProductService : BaseService<Product, IProductRepository, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>, IProductService
    {
        public ProductService(IProductRepository contextInterface, IBrandRepository brandRepository, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        {
            _brandRepository = brandRepository;
        }
        private readonly IBrandRepository _brandRepository;

        public override List<long> CreateMultiple(List<InputCreateProduct> listInputCreateProduct)
        {
            if (listInputCreateProduct.Count == 0)
                throw new ArgumentNullException();
            List<BrandDTO>? listRelatedBrands = _brandRepository.GetListByListId((from i in listInputCreateProduct select i.BrandId).ToList());
            if (listRelatedBrands == null || listRelatedBrands.Count == 0)
                throw new NotFoundException("ID da marca não localizado.");
            if (listInputCreateProduct.Any(x => x.Quantity < 0))
                throw new InvalidArgumentException("Quantidade inválida!");
            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(Product)), listInputCreateProduct.Count);
            var id = idRange.FirstId;

            var productsToCreate = (from inputCreateProduct in listInputCreateProduct select new ProductDTO().Create(id++, inputCreateProduct)).ToList();
            return _repository.CreateMultiple(productsToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateProduct> listInputIdentityUpdateProduct)
        {
            List<BrandDTO>? listRelatedBrands = _brandRepository.GetListByListId((from i in listInputIdentityUpdateProduct select i.InputUpdate.BrandId).ToList());
            if (listRelatedBrands == null || listRelatedBrands.Count == 0)
                throw new NotFoundException("ID da marca não localizado.");

            if (listInputIdentityUpdateProduct.Any(x => x.InputUpdate.Quantity < 0))
                throw new InvalidArgumentException("Quantidade inválida!");

            List<ProductDTO> ProductsToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateProduct select i.Id).ToList());
            if (ProductsToBeUpdated.Count == 0)
                throw new NotFoundException("Product ID não localizado!");

            var productsToUpdate = InternalUpdate(listInputIdentityUpdateProduct, ProductsToBeUpdated);
            return _repository.UpdateMultiple(productsToUpdate);
        }
    }
}
