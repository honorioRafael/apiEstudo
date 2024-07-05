using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Brand;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BrandService : BaseService<Brand, IBrandRepository, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand>, IBrandService
    {
        public BrandService(IBrandRepository contextInterface) : base(contextInterface)
        { }

        public override long Create(InputCreateBrand inputCreateBrand)
        {
            if (inputCreateBrand == null)
                throw new ArgumentNullException();

            var entry = new Brand(inputCreateBrand.Name, default);
            return _repository.Create(entry);
        }

        public override long Update(InputIdentityUpdateBrand inputIdentityUpdateBrand)
        {
            if (inputIdentityUpdateBrand == null)
                throw new ArgumentNullException();

            var entry = new Brand(inputIdentityUpdateBrand.InputUpdate.Name, default);
            return _repository.Update(entry);
        }
    }
}
