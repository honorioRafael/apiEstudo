using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BaseService<T, TRepository, TDTO> : IBaseService<T, TDTO> 
        where T : IBaseModel<T>
        where TDTO : IBaseDTO<TDTO>
        where TRepository : IBaseRepository<T, TDTO>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository contextInterface)
        {
            _repository = contextInterface;
        }

        public virtual TDTO? Get(int id)
        {
            var query = _repository.Get(id);

            return OutputToDTO(query);
        }

        public virtual List<TDTO>? GetAll()
        {
            var query = _repository.GetAll();

            return OutputToDTO(query);
        }

        public virtual bool Update(int id, BaseCreateViewModel<T> view)
        {
            throw new NotImplementedException();
        }

        public virtual bool Create(BaseCreateViewModel<T> view)
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

        internal TDTO OutputToDTO(T entrada)
        {
            return (TDTO)(dynamic)entrada;
        }

        internal List<TDTO> OutputToDTO(List<T> entrada)
        {
            return (from item in entrada select (TDTO)(dynamic)item).ToList();
        }

        internal T DTOToOutput(TDTO dto)
        {
            return (T)(dynamic)dto;
        }

        internal List<T> DTOToOutput(List<T> entrada)
        {
            return (from item in entrada select (T)(dynamic)item).ToList();
        }
    }
}
