using apiEstudo.Application.ViewModel;

namespace apiEstudo.Domain.Models
{
    public interface IBaseModel<T> 
    {
        public void UpdateSelf(IBaseViewModel view);
    }
}

