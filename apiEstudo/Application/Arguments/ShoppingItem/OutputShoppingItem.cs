namespace apiEstudo.Application.Arguments
{
    public class OutputShoppingItem : BaseOutput<OutputShoppingItem>
    {
        public double Quantity { get; set; }
        public OutputProduct Produto { get; set; }

        public OutputShoppingItem()
        { }

        public OutputShoppingItem(long id, double quantity, OutputProduct produto)
        {
            Quantity = quantity;
            Produto = produto;
            Id = id;
        }
    }
}
