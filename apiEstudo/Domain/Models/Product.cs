using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Product : BaseEntry<Product>, IBaseModel<Product>
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public virtual Marca Brand { get; private set; }

        public Product() { }
        
        public Product(string name, int quantity, int brandId, Marca brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }

        public static implicit operator ProductDTOSimplified(Product product)
        {
            return product == null ? default : new ProductDTOSimplified { Id = product.Id, Name = product.Name };
        }

        public static implicit operator ProductDTO(Product product)
        {
            return product == null ? default : new ProductDTO { Id = product.Id, Name = product.Name, Quantity = product.Quantity, Brand = product.Brand };
        }
    }
}
