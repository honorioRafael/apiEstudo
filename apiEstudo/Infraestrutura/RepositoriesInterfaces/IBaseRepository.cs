using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry>
        where TEntry : BaseEntry<TEntry>
    {
        public long Create(TEntry classe);
        public List<int> CreateMultiple(List<TEntry> entry);
        public long Update(TEntry classe);
        public List<int> UpdateMultiple(List<TEntry> entry);
        public bool Delete(TEntry classe);
        public void DeleteMultiple(List<TEntry> entry);
        public List<TEntry>? GetAll();
        public TEntry? Get(int id);
        public TEntry? GetByName(string name);
        List<TEntry>? GetListByListId(List<int> listId);
    }
}
