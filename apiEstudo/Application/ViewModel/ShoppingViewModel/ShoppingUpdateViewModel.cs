using apiEstudo.Application.ViewModel.BaseViewModel;
using apiEstudo.Application.ViewModelInterfaces.IShoppingViewModel;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel.ShoppingViewModel
{
    public class ShoppingUpdateViewModel : BaseUpdateViewModel<Shopping>, IShoppingUpdateViewModel
    {
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
    }
}
