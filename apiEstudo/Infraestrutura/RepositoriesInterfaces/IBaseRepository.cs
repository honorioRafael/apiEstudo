using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
    {
        List<TEntry>? GetAll();
        TEntry? Get(int id);
        List<TEntry>? GetListByListId(List<int> listId);
        int Create(TEntry classe);
        List<int> CreateMultiple(List<TEntry> entry);
        int Update(TEntry classe);
        List<int> UpdateMultiple(List<TEntry> entry);
        bool Delete(TEntry classe);
        void DeleteMultiple(List<TEntry> entry);
    }

    public interface IBaseRepository_1<TEntry> : IBaseRepository<TEntry, BaseInputCreate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0>
        where TEntry : BaseEntry<TEntry>
    { }

    public interface IBaseRepository_2<TEntry, TInputCreate, TInputUpdate, TInputIdentityUpdate> : IBaseRepository<TEntry, TInputCreate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0, TInputUpdate, TInputIdentityUpdate>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
    { }
}
