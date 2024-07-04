using apiEstudo.Application.ViewModel;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBaseService<T> 
    {
        public bool Create(T classe);
        public bool Update(int id, IBaseViewModel view);
        public bool Delete(int id);
        public List<T>? GetAll();
        public T? Get(int id);
        List<T>? GetListByListId(List<int> listId);
    }
}
