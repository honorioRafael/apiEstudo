using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>
    {
        #region Properties
        public double Value { get; private set; }
        public long EmployeeId { get; private set; }
        public long ShippingStatusId { get; private set; }

        #region Internal
        public virtual Employee Employee { get; private set; }
        public virtual ShippingStatus ShippingStatus { get; set; }
        #endregion

        #region External
        public virtual List<ShoppingItem>? ListShoppingItem { get; private set; }
        #endregion

        #endregion

        public Shopping(long employeeid, double value, long shippingStatusId, Employee employee, ShippingStatus shippingStatus)
        {
            EmployeeId = employeeid;
            Value = value;
            Employee = employee;
            ShippingStatusId = shippingStatusId;
            ShippingStatus = shippingStatus;
        }

        public Shopping() { }

        public static implicit operator ShoppingDTO(Shopping shopping)
        {
            return shopping == null ? default : new ShoppingDTO().Create(
                shopping.Id,
                new ShoppingExternalPropertiesDTO(shopping.EmployeeId, shopping.Value),
                new ShoppingInternalPropertiesDTO(shopping.ShippingStatusId).LoadInternalData(shopping.Id, shopping.CreationDate, shopping.ChangeDate));
        }

        public static implicit operator Shopping(ShoppingDTO dto)
        {
            return dto == null ? default : new Shopping(dto.ExternalPropertiesDTO.EmployeeId, dto.ExternalPropertiesDTO.Value, dto.InternalPropertiesDTO.ShippingStatusId, null, null)
                .LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
