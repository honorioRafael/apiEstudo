namespace apiEstudo.Domain.Models
{
    public class Product : BaseEntry<Product>
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; private set; }
        public virtual List<Shopping> ListShopping { get; set; }

        public Product() { }

        public Product(string name, int quantity, int brandId, Brand brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }

        //public static implicit operator ProductDTOSimplified(Product product)
        //{
        //    return product == null ? default : new ProductDTOSimplified { Id = product.Id, Name = product.Name };
        //}

        //public static implicit operator ProductDTO(Product product)
        //{
        //    return product == null ? default : new ProductDTO { Id = product.Id, Name = product.Name, Quantity = product.Quantity, Brand = product.Brand };
        //}
    }
}
