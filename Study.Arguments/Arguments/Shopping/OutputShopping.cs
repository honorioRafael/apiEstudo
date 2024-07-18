namespace Study.Arguments.Arguments
{
    public class OutputShopping : BaseOutput<OutputShopping>
    {
        public double Value { get; private set; }
        public long EmployeeId { get; private set; }
        public long ShippingStatusID { get; private set; }
        public virtual OutputEmployee Employee { get; private set; }
        public virtual List<OutputShoppingItem> Products { get; private set; }
        public virtual OutputShippingStatus ShippingStatus { get; private set; }

        public OutputShopping()
        {

        }

        public OutputShopping(double value, long employeeId, long shippingStatusId, OutputEmployee employee, List<OutputShoppingItem> products, OutputShippingStatus shippingStatus)
        {
            Value = value;
            EmployeeId = employeeId;
            ShippingStatus = shippingStatus;
            Employee = employee;
            Products = products;
            ShippingStatus = shippingStatus;
        }
    }
}
