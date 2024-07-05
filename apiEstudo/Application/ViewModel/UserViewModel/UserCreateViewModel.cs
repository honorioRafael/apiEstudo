﻿using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IUserViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.UserViewModel
{
    public class UserCreateViewModel : BaseCreateViewModel<User>, IUserCreateViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}