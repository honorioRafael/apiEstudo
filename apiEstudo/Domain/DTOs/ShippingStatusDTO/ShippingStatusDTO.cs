using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class ShippingStatusDTO : BaseDTO_1<OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>
    {
        public ShippingStatusDTO() { }

        public static implicit operator OutputShippingStatus(ShippingStatusDTO dto)
        {
            return dto == null ? default : new OutputShippingStatus(dto.InternalPropertiesDTO.Id, "desc");
        }

        public static implicit operator ShippingStatusDTO(OutputShippingStatus output)
        {
            return output == null ? default : new ShippingStatusDTO().Create(output.Id,
                new ShippingStatusInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
