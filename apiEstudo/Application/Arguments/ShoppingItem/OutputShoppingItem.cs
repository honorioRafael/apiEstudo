﻿namespace apiEstudo.Application.Arguments
{
    public class OutputShoppingItem : BaseOutput<OutputShoppingItem>
    {
        public double Quantity { get; set; }
        public OutputProduct Produto { get; set; }

        public OutputShoppingItem()
        { }

        public OutputShoppingItem(double quantity, OutputProduct produto)
        {
            Quantity = quantity;
            Produto = produto;
        }
    }
}