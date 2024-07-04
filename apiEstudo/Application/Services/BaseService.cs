using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        private IBaseRepository<T> _repository { get; set; }

        public BaseService(IBaseRepository<T> contextInterface)
        {
            _repository = contextInterface;
        }
        public T? Get(int id)
        {
            var query = _repository.Get(id);

            return query;
        }

        public List<T>? GetAll()
        {
            var query = _repository.GetAll();
            var resp = (from item in query
                        select item).ToList();

            return resp;
        }

        public List<T>? GetListByListId(List<int> listId)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, IBaseViewModel view)
        {
            var query = _repository.Get(id);
            if (query == null) return false;
            
            _repository.Update(query, view);
            return true;
        }

        public bool Create(T classe)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var query = _repository.Get(id);
            if (query == null) return false;

            _repository.Delete(query);
            return true;
        }
    }
}
