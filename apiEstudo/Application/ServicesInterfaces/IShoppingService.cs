﻿using apiEstudo.Application.ViewModel.ShoppingViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<Shopping, ShoppingDTO>
    {
        public bool Create(ShoppingCreateViewModel view);
    }
}