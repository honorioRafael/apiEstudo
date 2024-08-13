using Study.Arguments.Arguments;
using Study.Arguments.CustomException;
using Study.Arguments.CustomFunction;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Base;

namespace Study.Domain.Service
{
    public class BrandService : BaseService<IBrandRepository, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>, IBrandService
    {
        public BrandService(IBrandRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public override List<long> CreateMultiple(List<InputCreateBrand> listInputCreateBrand)
        {
            if (listInputCreateBrand == null)
                throw new ArgumentNullException();

            var rangeId = _idControlRepository.GetRangeId(TableName.GetNameId("Brand"), listInputCreateBrand.Count);
            var id = rangeId.FirstId;

            var createdBrand = (from inputCreateBrand in listInputCreateBrand
                                select new BrandDTO().Create(id++, inputCreateBrand)).ToList();
            return _repository.CreateMultiple(createdBrand);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateBrand> listInputIdentityUpdateBrand)
        {
            if (listInputIdentityUpdateBrand == null)
                throw new ArgumentNullException();

            List<BrandDTO> brandsToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateBrand select i.Id).ToList());
            if (brandsToBeUpdated.Count != listInputIdentityUpdateBrand.Count)
                throw new NotFoundException("Há um ID de marca inválido na lista de atualização.");

            var updatedBrands = (from inputIdentityUpdateBrand in listInputIdentityUpdateBrand
                                 let inputUpdateBrand = inputIdentityUpdateBrand.InputUpdate
                                 let brandToUpdate = (from j in brandsToBeUpdated where j.InternalPropertiesDTO.Id == inputIdentityUpdateBrand.Id select j).FirstOrDefault()
                                 select brandToUpdate.Update(inputUpdateBrand)).ToList();
            return _repository.UpdateMultiple(updatedBrands);
        }
    }
}
