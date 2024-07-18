namespace Study.Domain.DTO
{
    public class BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>
        where TAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<TAuxiliaryPropertiesDTO>
    {
    }

    public class BaseAuxiliaryPropertiesDTO_0 : BaseAuxiliaryPropertiesDTO<BaseAuxiliaryPropertiesDTO_0>
    { }
}
