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

        public int Create(InputCreateBrand inputCreateBrand)
        {
            return CreateMultiple([inputCreateBrand]).FirstOrDefault();
        }

        public override List<int> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            if (listInputCreateBrand == null)
                throw new ArgumentNullException();           
                
            var createdBrand = InternalCreate(listInputCreateBrand);
            return _repository.CreateMultiple(createdBrand);
        }

        public int Update(InputIdentityUpdateBrand inputIdentityUpdateBrand)
        {
            if (inputIdentityUpdateBrand == null)
                throw new ArgumentNullException();

            //var originalBrand = _repository.Get(inputIdentityUpdateBrand.Id);
            //if (originalBrand == null) throw new ArgumentNullException();
            
            return base.Update(inputIdentityUpdateBrand);// _repository.Update(new Brand(inputIdentityUpdateBrand.InputUpdate.Name).LoadInternalData(originalBrand.Id, originalBrand.CreationDate, originalBrand.ChangeDate).SetChangeDate());
        }
    }
}
