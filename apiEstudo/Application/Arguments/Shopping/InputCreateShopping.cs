using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateShopping : BaseInputCreate<InputCreateShopping>
    {
        public int EmployeeId { get; set; }
        public List<InputCreateShoppingList> Products { get; set; }
        public double Value { get; set; }
    }
}
