namespace apiEstudo.Application.Arguments
{
    public class OutputShoppingList : BaseOutput<OutputShoppingList>
    {
        public double Quantity { get; set; }
        public OutputProduct Produto { get; set; }

        public OutputShoppingList()
        { }

        public OutputShoppingList(double quantity, OutputProduct produto)
        {
            Quantity = quantity;
            Produto = produto;
        }
    }
}
