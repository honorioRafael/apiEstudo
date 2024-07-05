using apiEstudo.Application.ViewModelInterfaces.IBaseUpdateViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.BaseViewModel
{
    public class BaseUpdateViewModel<T> : IBaseUpdateViewModel<T> where T : IBaseModel<T>
    {
        public int Id { get; set; }
    }
}
