using Study.Arguments.Arguments;

namespace Study.Domain.DTO
{
    public class BrandDTO : BaseDTO<InputCreateBrand, InputUpdateBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>
    {
        public BrandDTO() { }

        public static implicit operator OutputBrand(BrandDTO dto)
        {
            return dto == null ? default : new OutputBrand(dto.ExternalPropertiesDTO.Name).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator BrandDTO(OutputBrand output)
        {
            return output == null ? default : new BrandDTO().Create(output.Id,
                new BrandExternalPropertiesDTO(output.Name),
                new BrandInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
