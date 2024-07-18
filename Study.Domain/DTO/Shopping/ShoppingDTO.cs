using Study.Arguments.Arguments;

namespace Study.Domain.DTO
{
    public class ShoppingDTO : BaseDTO<InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>
    {
        public ShoppingDTO() { }

        public static implicit operator OutputShopping(ShoppingDTO dto)
        {
            return dto == null ? default : new OutputShopping(dto.ExternalPropertiesDTO.Value, dto.ExternalPropertiesDTO.EmployeeId, dto.InternalPropertiesDTO.ShippingStatusId, dto.AuxiliaryPropertiesDTO.EmployeeDTO, null, dto.AuxiliaryPropertiesDTO.ShippingStatusDTO).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator ShoppingDTO(OutputShopping output)
        {
            return output == null ? default : new ShoppingDTO().Create(output.Id,
                new ShoppingExternalPropertiesDTO(output.EmployeeId, output.Value),
                new ShoppingInternalPropertiesDTO(output.ShippingStatusID).LoadInternalData(output.Id, output.CreationDate, output.ChangeDate),
                new ShoppingAuxiliaryPropertiesDTO(output.Employee, output.ShippingStatus));
        }
    }
}
