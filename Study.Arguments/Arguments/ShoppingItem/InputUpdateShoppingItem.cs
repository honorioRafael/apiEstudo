namespace Study.Arguments.Arguments
{
    public class InputUpdateShoppingItem : BaseInputUpdate<InputUpdateShoppingItem>
    {
        public long ProductId { get; set; }
        public double Quantity { get; set; }
    }
}
