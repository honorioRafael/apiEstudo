using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry, TInputCreate>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
    {
        List<TEntry>? GetAll();
        TEntry? Get(int id);
        List<TEntry>? GetListByListId(List<int> listId);
        int Create(TEntry classe);
        List<int> CreateMultiple(List<TEntry> entry);
        int Update(TEntry classe);
        List<int> UpdateMultiple(List<TEntry> entry);
        void Delete(TEntry classe);
        void DeleteMultiple(List<TEntry> entry);
    }

    public interface IBaseRepository_1<TEntry> : IBaseRepository<TEntry, BaseInputCreate_0>
        where TEntry : BaseEntry<TEntry>
    { }
}
