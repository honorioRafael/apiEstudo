namespace apiEstudo.Domain.Models
{
    public class Product : BaseEntry<Product>
    {
        #region Properties
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }

        #region Internal
        public virtual Brand Brand { get; private set; }

        #endregion

        #region External
        public virtual List<ShoppingItem> ListShoppingList { get; set; }

        #endregion

        #endregion

        public Product(string name, int quantity, long brandId, Brand brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }
        public Product() { }


    }
}
