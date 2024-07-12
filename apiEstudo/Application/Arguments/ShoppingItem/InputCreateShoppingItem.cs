namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingItem : BaseInputCreate<InputCreateShoppingItem>
    {
        private int ShoppingId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }

        public InputCreateShoppingItem(int shoppingId, int productId, double quantity)
        {
            ShoppingId = shoppingId;
            ProductId = productId;
            Quantity = quantity;
        }

        public InputCreateShoppingItem() { }
    }
}
