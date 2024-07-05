using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModelInterfaces.IBaseViewModel
{
    public interface IBaseCreateViewModel<T> where T : IBaseModel<T>
    {
    }
}
