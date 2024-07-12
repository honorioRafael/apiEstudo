using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputInternalCreateShoppingItem : BaseInputInternalCreate<InputInternalCreateShoppingItem>
    {
        public InputInternalCreateShoppingItem(int shoppingId)
        {
            ShoppingId = shoppingId;
        }

        public int ShoppingId { get; set; }
    }
}
