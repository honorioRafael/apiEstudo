namespace apiEstudo.Application.Arguments
{
    public class OutputShoppingItem : BaseOutput<OutputShoppingItem>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public OutputProduct Produto { get; set; }

        public OutputShoppingItem()
        { }

        public OutputShoppingItem(int id, double quantity, OutputProduct produto)
        {
            Quantity = quantity;
            Produto = produto;
            Id = id;
        }
    }
}
