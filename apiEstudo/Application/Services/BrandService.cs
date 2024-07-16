using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Brand;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BrandService : BaseService_2<Brand, IBrandRepository, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>, IBrandService
    {
        public BrandService(IBrandRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public override List<long> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            if (listInputCreateBrand == null)
                throw new ArgumentNullException();

            var rangeId = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(Brand)), listInputCreateBrand.Count);
            var id = rangeId.FirstId;

            var createdBrand = (from inputCreateBrand in listInputCreateBrand
                                select new BrandDTO().Create(id++, inputCreateBrand)).ToList();
            return _repository.CreateMultiple(createdBrand);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            if (listInputIdentityUpdateBrand == null)
                throw new ArgumentNullException();

            List<BrandDTO> BrandsToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateBrand select i.Id).ToList());
            if (BrandsToBeUpdated.Count == 0)
                throw new NotFoundException("Há um ID de marca inválido na lista de atualização.");

            var BrandToUpdate = InternalUpdate(listInputIdentityUpdateBrand, BrandsToBeUpdated);
            return _repository.UpdateMultiple(BrandToUpdate);
        }
    }
}
