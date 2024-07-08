﻿using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShoppingRepository : BaseRepository<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<Shopping>? GetAll()
        {
            return _dbset.Include(x => x.Product).Include(x => x.Employee).ToList();
        }

        public override Shopping? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).Include(x => x.Product).Include(x => x.Employee).AsNoTracking().FirstOrDefault();
        }
    }
}
