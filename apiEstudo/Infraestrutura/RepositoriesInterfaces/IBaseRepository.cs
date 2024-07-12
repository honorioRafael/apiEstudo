using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry, TInputCreate, TInputUpdate>
        where TEntry : BaseEntry<TEntry>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
    {
        public List<TEntry>? GetAll();
        public TEntry? Get(int id);
        List<TEntry>? GetListByListId(List<int> listId);
        public int Create(TInputCreate classe);
        public List<int> CreateMultiple(List<TInputCreate> entry);
        public int Update(TEntry classe);
        public List<int> UpdateMultiple(List<TEntry> entry);
        public bool Delete(TEntry classe);
        public void DeleteMultiple(List<TEntry> entry);
    }
}
