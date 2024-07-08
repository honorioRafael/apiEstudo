using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingList : BaseInputCreate<InputCreateShoppingList>
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
