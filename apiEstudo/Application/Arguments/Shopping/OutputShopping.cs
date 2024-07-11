﻿namespace apiEstudo.Application.Arguments
{
    public class OutputShopping : BaseOutput<OutputShopping>
    {
        public double Value { get; private set; }
        public virtual OutputEmployee Employee { get; private set; }
        public virtual List<OutputShoppingItem> Products { get; private set; }
        public virtual OutputShippingStatus ShippingStatus { get; private set; }

        public OutputShopping()
        {

        }

        public OutputShopping(double value, OutputEmployee employee, List<OutputShoppingItem> products, OutputShippingStatus shippingStatus)
        {
            Value = value;
            Employee = employee;
            Products = products;
            ShippingStatus = shippingStatus;
        }
    }
}
