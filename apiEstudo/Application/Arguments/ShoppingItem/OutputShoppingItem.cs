namespace apiEstudo.Application.Arguments
{
    public class OutputShoppingItem : BaseOutput<OutputShoppingItem>
    {
        public double Quantity { get; set; }
        public long ProductId { get; set; }
        public OutputProduct Produto { get; set; }

        public OutputShoppingItem()
        { }

        public OutputShoppingItem(long id, double quantity, long productId, OutputProduct produto)
        {
            Quantity = quantity;
            ProductId = productId;
            Produto = produto;
            Id = id;
        }
    }
}
