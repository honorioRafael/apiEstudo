﻿using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShoppingItemRepository : BaseRepository<ShoppingItem>, IShoppingItemRepository
    {
        public ShoppingItemRepository(ConnectionContext context) : base(context)
        { }
    }
}