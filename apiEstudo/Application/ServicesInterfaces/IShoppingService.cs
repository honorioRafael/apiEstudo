using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputCreateShoppingComplete, InputInternalCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public int UpdateShippingStatusApprove(InputApproveShippingStatus inputApproveShippingStatus);
        public int UpdateShippingStatusCancel(InputCancelShippingStatus inputCancelShippingStatus);
    }
}
