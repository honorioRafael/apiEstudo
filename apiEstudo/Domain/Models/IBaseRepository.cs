using apiEstudo.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Domain.Models
{
    public interface IBaseRepository<T>
    {
        public void Add(T classe);
        public List<T>? GetAll();
        public T? Get(int id);
        List<T>? GetListByListId(List<int> listId);

    }
}
