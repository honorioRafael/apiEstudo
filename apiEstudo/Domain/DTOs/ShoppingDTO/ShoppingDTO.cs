using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class ShoppingDTO : BaseDTO<InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>
    {
        public ShoppingDTO() { }

        public static implicit operator OutputShopping(ShoppingDTO dto)
        {
            return dto == null ? default : new OutputShopping(dto.ExternalPropertiesDTO.Value, dto.ExternalPropertiesDTO.EmployeeId, dto.InternalPropertiesDTO.ShippingStatusId, null, null, null).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator ShoppingDTO(OutputShopping output)
        {
            return output == null ? default : new ShoppingDTO().Create(output.Id,
                new ShoppingExternalPropertiesDTO(output.EmployeeId, output.Value),
                new ShoppingInternalPropertiesDTO(output.ShippingStatusID).LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
