using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Product : BaseEntry<Product>, IBaseModel<Product>
    {

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public int BrandId { get; private set; }
        public virtual Marca Brand { get; private set; }

        public Product() { }
        public Product(string nome, int quantidade, int marcaId)
        {
            Name = nome;
            Quantity = quantidade;
            BrandId = marcaId;
        }
        public Product(string name, int quantity, int brandId, Marca brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }

        public void UpdateProduct(ProductViewModel productView)
        {
            Name = productView.Name;
            Quantity = productView.Quantity;
            BrandId = productView.BrandId;
        }

        public void UpdateSelf(IBaseViewModel view)
        {
            throw new NotImplementedException();
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
