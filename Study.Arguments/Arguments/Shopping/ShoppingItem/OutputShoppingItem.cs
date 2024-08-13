using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class OutputShoppingItem : BaseOutput<OutputShoppingItem>
    {
        public double Quantity { get; set; }
        public long ProductId { get; set; }
        public OutputProduct Product { get; set; }

        public OutputShoppingItem()
        { }

        public OutputShoppingItem(long id, double quantity, long productId, OutputProduct produto)
        {
            Quantity = quantity;
            ProductId = productId;
            Product = produto;
            Id = id;
        }
    }
}
