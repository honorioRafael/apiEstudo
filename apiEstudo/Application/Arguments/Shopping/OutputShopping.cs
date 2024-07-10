using apiEstudo.Domain.Model;

namespace apiEstudo.Application.Arguments
{
    public class OutputShopping : BaseOutput<OutputShopping>
    {
        public double Value { get; private set; }
        public virtual OutputEmployee Employee { get; private set; }
        public virtual List<OutputShoppingItem> Products { get; private set; }

        public OutputShopping()
        {
            
        }

        public OutputShopping(double value, OutputEmployee employee, List<OutputShoppingItem> products)
        {
            Value = value;
            Employee = employee;
            Products = products;
        }
    }
}
