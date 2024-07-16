using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry, TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : IBaseRepository<TEntry, TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO<TInputCreate, TInputUpdate, TOutput, TDTO, TExternalPropertiesDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>, new()
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<TEntry> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntry>();
        }

        #region Create
        public virtual long Create(TDTO entry)
        {
            return CreateMultiple([entry]).First();
        }

        public virtual List<long> CreateMultiple(List<TDTO> listDto)
        {
            var listEntry = FromDTOToEntry(listDto);
            _context.AddRange((from i in listEntry select i.SetCreationDate()));
            _context.SaveChanges();

            return (from i in listEntry select i.Id).ToList();
        }

        #endregion

        #region Get
        public virtual List<TDTO>? GetAll()
        {
            return FromEntryToDTO(_dbset.ToList());
        }

        public virtual List<TDTO>? GetListByListId(List<long> listId)
        {
            return FromEntryToDTO(_dbset.Where(x => listId.Contains(x.Id)).AsNoTracking().ToList());
        }

        public virtual TDTO? Get(long id)
        {
            return FromEntryToDTO(_dbset.Where(x => x.Id == id).AsNoTracking().FirstOrDefault());
        }

        #endregion

        #region Update
        public virtual long Update(TDTO inputUpdate)
        {
            return UpdateMultiple([inputUpdate]).FirstOrDefault();
        }

        public List<long> UpdateMultiple(List<TDTO> listInputUpdate)
        {
            var entry = FromDTOToEntry(listInputUpdate);
            _context.UpdateRange((from i in entry select i.SetChangeDate()));
            _context.SaveChanges();

            return (from i in entry select i.Id).ToList();
        }

        #endregion

        #region Delete
        public virtual void Delete(TDTO dto)
        {
            DeleteMultiple([dto]);
        }

        public void DeleteMultiple(List<TDTO> dto)
        {
            var entry = FromDTOToEntry(dto);
            _context.RemoveRange(entry);
            _context.SaveChanges();
        }

        #endregion

        #region Internal Methods

        internal static TEntry FromDTOToEntry(TDTO dto)
        {
            return (TEntry)(dynamic)dto;
        }

        internal static List<TEntry> FromDTOToEntry(List<TDTO> listDto)
        {
            return (from i in listDto select (TEntry)(dynamic)i).ToList();
        }

        internal static TDTO? FromEntryToDTO(TEntry? entry)
        {
            return (TDTO)(dynamic)entry;
        }

        internal static List<TDTO>? FromEntryToDTO(List<TEntry>? listEntry)
        {
            return (from i in listEntry select (TDTO)(dynamic)i).ToList();
        }

        #endregion
    }

    public abstract class BaseRepository_1<TEntry, TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO> : BaseRepository<TEntry, BaseInputCreate_0, BaseInputUpdate_0, TOutput, TDTO, BaseExternalPropertiesDTO_0, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>, IBaseRepository_1<TEntry, TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TEntry : BaseEntry<TEntry>, new()
        where TOutput : BaseOutput<TOutput>
        where TDTO : BaseDTO_1<TOutput, TDTO, TInternalPropertiesDTO, TAuxiliaryPropertiesDTO>
        where TInternalPropertiesDTO : BaseInternalPropertiesDTO<TInternalPropertiesDTO>, new()
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>, new()
    {
        protected BaseRepository_1(ConnectionContext context) : base(context)
        { }
    }
}
