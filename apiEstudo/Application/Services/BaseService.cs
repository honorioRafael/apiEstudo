using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BaseService<T, TDTO> : IBaseService<T, TDTO> where TDTO : IBaseDTO<TDTO>
    {
        private IBaseRepository<T> _repository { get; set; }

        public BaseService(IBaseRepository<T> contextInterface)
        {
            _repository = contextInterface;
        }
        public virtual TDTO? Get(int id)
        {
            var query = _repository.Get(id);

            return query;
        }

        public virtual List<TDTO>? GetAll()
        {
            var query = _repository.GetAll();
            var resp = (from item in query
                        select item).ToList();

            return resp;
        }

        public virtual bool Update(int id, IBaseViewModel view)
        {
            throw new NotImplementedException();
        }

        public virtual bool Create(T classe)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(int id)
        {
            var query = _repository.Get(id);
            if (query == null) return false;

            _repository.Delete(query);
            return true;
        }

        List<TDTO>? IBaseService<T, TDTO>.GetListByListId(List<int> listId)
        {
            throw new NotImplementedException();
        }
    }
}
