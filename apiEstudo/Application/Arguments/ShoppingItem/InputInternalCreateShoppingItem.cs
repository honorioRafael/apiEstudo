using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputInternalCreateShoppingItem : BaseInputInternalCreate<InputInternalCreateShoppingItem>
    {
        public InputInternalCreateShoppingItem(long shoppingId)
        {
            ShoppingId = shoppingId;
        }

        public long ShoppingId { get; set; }
    }
}
