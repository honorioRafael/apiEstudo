using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

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

        public static implicit operator ProductDTO(Product product)
        {
            return product == null ? default : new ProductDTO().Create(
                product.Id,
                new ProductExternalPropertiesDTO(product.Name, product.Quantity, product.BrandId),
                new ProductInternalPropertiesDTO().LoadInternalData(product.Id, product.CreationDate, product.ChangeDate));
        }

        public static implicit operator Product(ProductDTO dto)
        {
            return dto == null ? default : new Product(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Quantity, dto.ExternalPropertiesDTO.BrandId, null)
                .LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
