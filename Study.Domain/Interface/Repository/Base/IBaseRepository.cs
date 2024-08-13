using Study.Arguments.Arguments.Base;
using Study.Domain.DTO;

namespace Study.Domain.Interface.Repository.Base
{
    public interface IBaseRepository<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        List<TDTO>? GetAll();
        TDTO? Get(long id);
        List<TDTO>? GetListByListId(List<long> listId);
        long Create(TDTO classe);
        List<long> CreateMultiple(List<TDTO> entry);
        long Update(TDTO classe);
        List<long> UpdateMultiple(List<TDTO> entry);
        void Delete(TDTO classe);
        void DeleteMultiple(List<TDTO> entry);
    }
    public interface IBaseRepository_1<TOutput, TDTO, TInternalPropertiesDTO> : IBaseRepository<BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, BaseAuxiliaryPropertiesDTO_0>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO_2<TOutput, TDTO, TInternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
    { }

    public interface IBaseRepository_2<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : IBaseRepository<BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    { }
}
