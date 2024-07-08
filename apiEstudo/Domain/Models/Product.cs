using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.Models
{
    public class Product : BaseEntry<Product>
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; private set; }
        public virtual List<ShoppingList> ListShoppingList { get; set; }

        public Product() { }

        public Product(string name, int quantity, int brandId, Brand brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }

        public static implicit operator OutputProduct(Product product)
        {
            return product == null ? default : new OutputProduct(product.Name, product.Quantity, product.Brand).LoadInternalData(product.Id, product.CreationDate, product.ChangeDate);
        }
    }
}
