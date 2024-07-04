using apiEstudo.Application.ViewModel;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBaseService<T, TDTO> 
    {
        public bool Create(T classe);
        public abstract bool Update(int id, IBaseViewModel view);
        public bool Delete(int id);
        public List<TDTO>? GetAll();
        public TDTO? Get(int id);
        List<TDTO>? GetListByListId(List<int> listId);
    }
}
