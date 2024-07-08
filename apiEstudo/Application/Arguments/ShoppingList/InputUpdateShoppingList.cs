using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateShoppingList : BaseInputUpdate<InputUpdateShoppingList>
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
