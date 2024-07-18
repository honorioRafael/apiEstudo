using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry, TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TEntry : BaseEntry<TEntry>
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
    public interface IBaseRepository_1<TEntry> : IBaseRepository<TEntry, BaseInputCreate_0, BaseInputUpdate_0, BaseOutput_0, BaseDTO_0, BaseExternalPropertiesDTO_0, BaseInternalPropertiesDTO_0, BaseAuxiliaryPropertiesDTO_0>
        where TEntry : BaseEntry<TEntry>
    { }

    public interface IBaseRepository_2<TEntry, TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : IBaseRepository<TEntry, BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TEntry : BaseEntry<TEntry>, new()
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    { }
}
