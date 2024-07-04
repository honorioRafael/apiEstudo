using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BaseService<T, TDTO> : IBaseService<T, TDTO> 
        where T : BaseEntry<T>, IBaseModel<T>
        where TDTO : IBaseDTO<TDTO>
    
    {
        private IBaseRepository<T, TDTO> _repository { get; set; }

        public BaseService(IBaseRepository<T, TDTO> contextInterface)
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

        public virtual bool Update(int id, BaseViewModel<T> view)
        {
            throw new NotImplementedException();
        }

        public virtual bool Create(BaseViewModel<T> view)
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
