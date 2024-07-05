﻿using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry> : IBaseRepository<TEntry>
        where TEntry : BaseEntry<TEntry>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<TEntry> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntry>();
        }

        public virtual long Create(TEntry entry)
        {
            _context.Add(entry.SetCreationDate());
            _context.SaveChanges();

            return entry.Id;
        }

        public virtual List<TEntry>? GetAll()
        {
            return _dbset.ToList();
        }

        public virtual List<TEntry>? GetListByListId(List<int> listId)
        {
            return _dbset.Where(x => listId.Contains(x.Id)).ToList();
        }

        public virtual TEntry? Get(int id)
        {
            return _dbset.Find(id);
        }

        public virtual TEntry? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual long Update(TEntry entry)
        {
            _context.Update(entry.SetChangeDate());
            _context.SaveChanges();

            return entry.Id;
        }

        public virtual bool Delete(TEntry classe)
        {
            _context.Remove(classe);
            _context.SaveChanges();

            return true;
        }
    }
}
