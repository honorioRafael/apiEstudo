﻿using apiEstudo.Application.ViewModelInterfaces.IBaseUpdateViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.BaseViewModel
{
    public class BaseCreateViewModel<T> : IBaseCreateViewModel<T> where T : IBaseModel<T>
    {
    }
}
