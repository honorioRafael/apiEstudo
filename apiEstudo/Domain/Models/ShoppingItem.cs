using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.Models
{
    public class ShoppingItem : BaseEntry<ShoppingItem>
    {
        #region Properties
        public int ShoppingId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }

        #region Internal
        public virtual Product Product { get; set; }
        public virtual Shopping Shopping { get; set; }
        #endregion

        #endregion

        public ShoppingItem(int shoppingId, int productId, double quantity, Product product, Shopping shopping)
        {
            ShoppingId = shoppingId;
            ProductId = productId;
            Quantity = quantity;
            Product = product;
            Shopping = shopping;
        }

        public ShoppingItem()
        { }

        public static implicit operator OutputShoppingItem(ShoppingItem shop)
        {
            return shop == null ? default : new OutputShoppingItem(shop.Id, shop.Quantity, shop.Product).LoadInternalData(shop.Id, shop.CreationDate, shop.ChangeDate);
        }
    }
}
