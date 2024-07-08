using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.Models
{
    public class ShoppingList : BaseEntry<ShoppingList>
    {
        public int ShoppingId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Shopping Shopping { get; set; }

        public ShoppingList()
        { }

        public ShoppingList(int shoppingId, int productId, double quantity, Product product, Shopping shopping)
        {
            ShoppingId = shoppingId;
            ProductId = productId;
            Quantity = quantity;
            Product = product;
            Shopping = shopping;
        }

        public static implicit operator OutputShoppingList(ShoppingList shop)
        {
            return shop == null ? default : new OutputShoppingList(shop.Quantity, shop.Product).LoadInternalData(shop.Id, shop.CreationDate, shop.ChangeDate);
        }
    }
}
