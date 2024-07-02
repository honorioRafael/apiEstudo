using apiEstudo.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Domain.Models
{
    public interface IBaseRepository<T>
    {
        public List<T>? GetAll();
        public T? Get(long id);
        List<T>? GetListByListId(List<long> listId);
    }
}
