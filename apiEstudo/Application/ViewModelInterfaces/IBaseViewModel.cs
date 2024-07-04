using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModelInterfaces
{
    public interface IBaseViewModel<T> where T : IBaseModel<T>
    {
    }
}
