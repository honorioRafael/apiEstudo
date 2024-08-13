using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputCreateShoppingItem : BaseInputCreate<InputCreateShoppingItem>
    {
        public long ProductId { get; set; }
        public double Quantity { get; set; }


        public InputCreateShoppingItem(int productId, double quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public InputCreateShoppingItem() { }
    }
}
