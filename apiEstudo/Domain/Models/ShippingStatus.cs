using apiEstudo.Domain.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class ShippingStatus : BaseEntry<ShippingStatus>
    {
        #region Properties
        #region Base Ignore
        [NotMapped]
        public override DateTime CreationDate { get => base.CreationDate; protected set => base.CreationDate = value; }
        [NotMapped]
        public override DateTime? ChangeDate { get => base.ChangeDate; protected set => base.ChangeDate = value; }
        #endregion

        public string Description { get; set; }

        public virtual List<Shopping> ListShoppings { get; set; }

        #endregion

        public ShippingStatus(string description, List<Shopping> listShoppings)
        {
            Description = description;
            ListShoppings = listShoppings;
        }
        public ShippingStatus()
        { }

        public static implicit operator ShippingStatusDTO(ShippingStatus shippingStatus)
        {
            return shippingStatus == null ? default : new ShippingStatusDTO().Create(
                shippingStatus.Id,
                new ShippingStatusInternalPropertiesDTO(shippingStatus.Description).LoadInternalData(shippingStatus.Id, shippingStatus.CreationDate, shippingStatus.ChangeDate));
        }

        public static implicit operator ShippingStatus(ShippingStatusDTO dto)
        {
            return dto == null ? default : new ShippingStatus(dto.InternalPropertiesDTO.Description, null).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
