using apiEstudo.Application.ViewModel;
using apiEstudo.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<T>
    {
        public void Create(T classe);
        public void Update(T classe, IBaseViewModel view);
        public void Delete(T classe);
        public List<T>? GetAll();
        public T? Get(int id);
        List<T>? GetListByListId(List<int> listId);
    }
}
