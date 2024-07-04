using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel
{
    public class BaseViewModel<T> : IBaseViewModel<T> where T : IBaseModel<T>
    {
    }
}
