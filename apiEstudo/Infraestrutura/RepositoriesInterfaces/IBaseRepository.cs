using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBaseRepository<T, TDTO> where TDTO : IBaseDTO<TDTO>
    {
        public void Create(T classe);
        public void Update(T classe);
        public void Delete(T classe);
        public List<T>? GetAll();
        public T? Get(int id);
        List<T>? GetListByListId(List<int> listId);
    }
}
