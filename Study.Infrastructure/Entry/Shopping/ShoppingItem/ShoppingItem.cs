using Study.Domain.DTO;

namespace Study.Infrastructure.Entry
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

        public static implicit operator ShoppingItemDTO(ShoppingItem shoppingItem)
        {
            return shoppingItem == null ? default : new ShoppingItemDTO().Create(
                shoppingItem.Id,
                new ShoppingItemExternalPropertiesDTO(shoppingItem.ProductId, shoppingItem.Quantity),
                new ShoppingItemInternalPropertiesDTO(shoppingItem.ShoppingId).LoadInternalData(shoppingItem.Id, shoppingItem.CreationDate, shoppingItem.ChangeDate),
                new ShoppingItemAuxiliaryPropertiesDTO(shoppingItem.Product, shoppingItem.Shopping));
        }

        public static implicit operator ShoppingItem(ShoppingItemDTO dto)
        {
            return dto == null ? default : new ShoppingItem(dto.InternalPropertiesDTO.ShoppingId, dto.ExternalPropertiesDTO.ProductId, dto.ExternalPropertiesDTO.Quantity, dto.AuxiliaryPropertiesDTO.ProductDTO, dto.AuxiliaryPropertiesDTO.ShoppingDTO)
                .LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
