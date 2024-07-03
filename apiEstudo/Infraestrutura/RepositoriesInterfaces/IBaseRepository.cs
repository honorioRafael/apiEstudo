using apiEstudo.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<T>
    {
        public void Add(T classe);
        public void Update(T classe);
        public void Delete(T classe);
        public List<T>? GetAll();
        public T? Get(int id);
        List<T>? GetListByListId(List<int> listId);
    }
}
