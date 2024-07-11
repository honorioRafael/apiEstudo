namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingItem : BaseInputCreate<InputCreateShoppingItem>
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
