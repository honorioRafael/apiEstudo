namespace apiEstudo.Domain.Models
{
    public class ShoppingItem : BaseEntry<ShoppingItem>
    {
        #region Properties
        public long ShoppingId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        #region Internal
        public virtual Product Product { get; set; }
        public virtual Shopping Shopping { get; set; }
        #endregion

        #endregion

        public ShoppingItem(long shoppingId, long productId, double quantity, Product product, Shopping shopping)
        {
            ShoppingId = shoppingId;
            ProductId = productId;
            Quantity = quantity;
            Product = product;
            Shopping = shopping;
        }

        public ShoppingItem()
        { }


    }
}
