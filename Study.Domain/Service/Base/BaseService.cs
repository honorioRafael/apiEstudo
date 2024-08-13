using Study.Arguments.Arguments.Base;
using Study.Arguments.CustomException;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Repository.Base;
using Study.Domain.Interface.Service;

namespace Study.Domain.Service.Base
{
    public abstract class BaseService<TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TRepository : IBaseRepository<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        protected readonly TRepository _repository;
        protected readonly IIdControlRepository _idControlRepository;

        public BaseService(TRepository contextInterface, IIdControlRepository idControlRepository)
        {
            _repository = contextInterface;
            _idControlRepository = idControlRepository;
        }

        #region Get
        public virtual TOutput? Get(long id)
        {
            return FromDTOToOutput(_repository.Get(id));
        }

        public virtual List<TOutput>? GetAll()
        {
            return FromDTOToOutput(_repository.GetAll());
        }

        public List<TOutput>? GetListByListId(List<long> listId)
        {
            return FromDTOToOutput(_repository.GetListByListId(listId));
        }

        #endregion

        #region Update
        public long Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            return UpdateMultiple([inputIdentityUpdate]).First();
        }

        public virtual List<long> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Create
        public long Create(TInputCreate inputCreate)
        {
            return CreateMultiple([inputCreate]).FirstOrDefault();
        }

        public virtual List<long> CreateMultiple(List<TInputCreate> listCreate)
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

        public virtual void DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            var ToBeDeleted = _repository.GetListByListId((from i in listInputIdentityDelete select i.Id).ToList());
            if (ToBeDeleted == null)
                throw new NotFoundException("Há um ID inválido na lista de exclusão.");

            _repository.DeleteMultiple(ToBeDeleted);
        }

        #endregion

        #region Internal Methods

        internal static TOutput FromDTOToOutput(TDTO dto)
        {
            return (TOutput)(dynamic)dto;
        }

        internal static List<TOutput> FromDTOToOutput(List<TDTO> listDto)
        {
            return (from i in listDto select (TOutput)(dynamic)i).ToList();
        }

        #endregion        
    }

    public abstract class BaseService_1<TRepository, TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : BaseService<TRepository, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>, IBaseService_1<TOutput>
        where TOutput : BaseOutput<TOutput>
        where TRepository : IBaseRepository_2<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TDTO : BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        protected BaseService_1(TRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository) { }
    }

    public abstract class BaseService_2<TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : BaseService<TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, BaseInputIdentityDelete_0, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>, IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput>
        where TRepository : IBaseRepository<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        protected BaseService_2(TRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }
    }
}
