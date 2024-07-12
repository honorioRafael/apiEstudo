using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputInternalCreateShopping : BaseInputInternalCreate<InputInternalCreateShopping>
    {
        public InputInternalCreateShopping(int shippingStatusId)
        {
            ShippingStatusId = shippingStatusId;
        }

        public int ShippingStatusId { get; set; }
    }
}
