using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel
{
    public class UserViewModel : BaseViewModel<User>, IUserViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
