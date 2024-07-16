using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class ShoppingDTO : BaseDTO<InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>
    {
        public ShoppingDTO() { }
    }
}
