namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingItem : BaseInputCreate<InputCreateShoppingItem>
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }


        public InputCreateShoppingItem(int productId, double quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public InputCreateShoppingItem() { }
    }
}
