using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntry>
        where TEntry : BaseEntry<TEntry>
    {
        public long Create(TEntry classe);
        public List<int> CreateMultiple(List<TEntry> entry);
        public long Update(TEntry classe);
        public bool Delete(TEntry classe);
        public List<TEntry>? GetAll();
        public TEntry? Get(int id);
        public TEntry? GetByName(string name);
        List<TEntry>? GetListByListId(List<int> listId);
    }
}
