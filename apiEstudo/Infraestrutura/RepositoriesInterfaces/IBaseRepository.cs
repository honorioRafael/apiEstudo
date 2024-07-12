using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry, TInputCreate, TInputUpdate, TInputCreateComplete, TInputInternalCreate>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
    {
        List<TEntry>? GetAll();
        TEntry? Get(int id);
        List<TEntry>? GetListByListId(List<int> listId);
        int Create(TInputCreate classe);
        List<int> CreateMultiple(List<TInputCreate> entry);
        List<int> CreateMultiple(List<TInputCreateComplete> listInputCreate);
        int Update(TEntry classe);
        List<int> UpdateMultiple(List<TEntry> entry);
        bool Delete(TEntry classe);
        void DeleteMultiple(List<TEntry> entry);
    }

    public interface IBaseRepository_1<TEntry> : IBaseRepository<TEntry, BaseInputCreate_0, BaseInputUpdate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0>
        where TEntry : BaseEntry<TEntry>
    { }

    public interface IBaseRepository_2<TEntry, TInputCreate, TInputUpdate> : IBaseRepository<TEntry, TInputCreate, TInputUpdate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
    { }
}
