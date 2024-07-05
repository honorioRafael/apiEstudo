using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IUserViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.UserViewModel
{
    public class UserUpdateViewModel : BaseUpdateViewModel<User>, IUserUpdateViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
