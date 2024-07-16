namespace apiEstudo.Domain.DTOs
{
    public class BaseExternalPropertiesDTO<TExternalPropertiesDTO>
        where TExternalPropertiesDTO : BaseExternalPropertiesDTO<TExternalPropertiesDTO>
    { }

    public class BaseExternalPropertiesDTO_0 : BaseExternalPropertiesDTO<BaseExternalPropertiesDTO_0> { }
}
