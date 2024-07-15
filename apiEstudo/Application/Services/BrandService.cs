using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Brand;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BrandService : BaseService_2<Brand, IBrandRepository, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand>, IBrandService
    {
        public BrandService(IBrandRepository contextInterface) : base(contextInterface)
        { }

        public long Create(InputCreateBrand inputCreateBrand)
        {
            return CreateMultiple([inputCreateBrand]).FirstOrDefault();
        }

        public override List<long> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            if (listInputCreateBrand == null)
                throw new ArgumentNullException();

            var createdBrand = InternalCreate(listInputCreateBrand);
            return _repository.CreateMultiple(createdBrand);
        }
        public override List<long> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            if (listInputIdentityUpdateBrand == null)
                throw new ArgumentNullException();

            List<Brand> BrandsToBeUpdated = GetListByListId((from i in listInputIdentityUpdateBrand select i.Id).ToList());
            if (BrandsToBeUpdated.Count == 0)
                throw new NotFoundException("Brand ID não localizado!");

            var BrandToUpdate = InternalUpdate(listInputIdentityUpdateBrand, BrandsToBeUpdated);
            return _repository.UpdateMultiple(BrandToUpdate);
        }
    }
}
