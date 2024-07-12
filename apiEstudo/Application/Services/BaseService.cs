using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public abstract class BaseService<TEntry, TRepository, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : IBaseService<TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TEntry : BaseEntry<TEntry>
        where TRepository : IBaseRepository<TEntry, TInputCreate, TInputUpdate, TInputCreateComplete, TInputInternalCreate>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository contextInterface)
        {
            _repository = contextInterface;
        }

        #region Get
        public virtual TOutput? Get(int id)
        {
            return EntryToOutput(_repository.Get(id));
        }

        public virtual List<TOutput>? GetAll()
        {
            return EntryToOutput(_repository.GetAll());
        }

        public List<TOutput>? GetListByListId(List<int> listId)
        {
            return EntryToOutput(_repository.GetListByListId(listId));
        }

        #endregion

        #region Update
        public virtual int Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Create
        public int Create(TInputCreate inputCreate)
        {
            return CreateMultiple([inputCreate]).FirstOrDefault();
        }

        public virtual List<int> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual List<int> CreateMultiple(List<TInputCreateComplete> listInputCreateComplete)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete
        public virtual void Delete(TInputIdentityDelete inputIdentityDelete)
        {
            var ToBeDeleted = _repository.Get(inputIdentityDelete.Id);
            if (ToBeDeleted == null)
                throw new NotFoundException("Não foi encontrado nenhum registro com o ID informado.");
            _repository.Delete(ToBeDeleted);
        }
        #endregion

        #region Internal Functions
        internal TOutput EntryToOutput(TEntry entrada)
        {
            return (TOutput)(dynamic)entrada;
        }

        internal List<TOutput> EntryToOutput(List<TEntry> entrada)
        {
            return (from item in entrada select (TOutput)(dynamic)item).ToList();
        }
        #endregion        
    }

    public abstract class BaseService_1<TEntry, TRepository, TOutput> : BaseService<TEntry, TRepository, BaseInputCreate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>, IBaseService_1<TOutput>
        where TOutput : BaseOutput<TOutput>
        where TEntry : BaseEntry<TEntry>
        where TRepository : IBaseRepository_1<TEntry>
    {
        protected BaseService_1(TRepository contextInterface) : base(contextInterface) { }
    }

    public abstract class BaseService_2<TEntry, TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : BaseService<TEntry, TRepository, TInputCreate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>, IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TEntry : BaseEntry<TEntry>
        where TRepository : IBaseRepository_2<TEntry, TInputCreate, TInputUpdate>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        protected BaseService_2(TRepository contextInterface) : base(contextInterface)
        { }
    }
}
