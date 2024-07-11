using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public abstract class BaseService<TEntry, TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
        where TEntry : BaseEntry<TEntry>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TRepository : IBaseRepository<TEntry>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository contextInterface)
        {
            _repository = contextInterface;
        }

        public virtual TOutput? Get(int id)
        {
            return EntryToOutput(_repository.Get(id));
        }

        public virtual List<TOutput>? GetAll()
        {
            return EntryToOutput(_repository.GetAll());
        }

        public virtual long Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        public virtual long Create(TInputCreate inputCreate)
        {
            return CreateMultiple([inputCreate]).FirstOrDefault();
        }

        public virtual List<long> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TInputIdentityDelete inputIdentityDelete)
        {
            var ToBeDeleted = _repository.Get(inputIdentityDelete.Id);
            if (ToBeDeleted == null)
                throw new NotFoundException("Não foi encontrado nenhum registro com o ID informado.");
            _repository.Delete(ToBeDeleted);
        }

        internal TOutput EntryToOutput(TEntry entrada)
        {
            return (TOutput)(dynamic)entrada;
        }

        internal List<TOutput> EntryToOutput(List<TEntry> entrada)
        {
            return (from item in entrada select (TOutput)(dynamic)item).ToList();
        }

        public List<TOutput>? GetListByListId(List<int> listId)
        {
            return EntryToOutput(_repository.GetListByListId(listId));
        }
    }

    public abstract class BaseService_1<TEntry, TRepository, TOutput> : BaseService<TEntry, TRepository, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TOutput : BaseOutput<TOutput>
        where TEntry : BaseEntry<TEntry>
        where TRepository : IBaseRepository<TEntry>
    {
        protected BaseService_1(TRepository contextInterface) : base(contextInterface) { }
    }
}
