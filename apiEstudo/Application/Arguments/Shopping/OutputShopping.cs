using apiEstudo.Domain.Model;

namespace apiEstudo.Application.Arguments
{
    public class OutputShopping : BaseOutput<OutputShopping>
    {
        public double Value { get; private set; }
        public DateTime TransationDate { get; private set; }
        public virtual OutputEmployee Employee { get; private set; }
        public virtual OutputProduct Product { get; private set; }

        public OutputShopping()
        {
            
        }

        public OutputShopping(double value, DateTime transationDate, OutputEmployee employee, OutputProduct product)
        {
            Value = value;
            TransationDate = transationDate;
            Employee = employee;
            Product = product;
        }
    }
}
