namespace apiEstudo.Application.Arguments
{
    public class InputUpdateShoppingItem : BaseInputUpdate<InputUpdateShoppingItem>
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
