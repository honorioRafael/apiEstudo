using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBaseService<T, TDTO> where T : IBaseModel<T>
    {
        public abstract bool Create(BaseCreateViewModel<T> view);
        public abstract bool Update(int id, BaseUpdateViewModel<T> view);
        public bool Delete(int id);
        public List<TDTO>? GetAll();
        public TDTO? Get(int id);
        List<TDTO>? GetListByListId(List<int> listId);
    }
}
