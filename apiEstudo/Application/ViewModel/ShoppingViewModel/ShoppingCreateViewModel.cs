using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IShoppingViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.ShoppingViewModel
{
    public class ShoppingCreateViewModel : BaseCreateViewModel<User>, IShoppingCreateViewModel
    {
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
    }
}
