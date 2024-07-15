using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputCreateShoppingComplete, InputInternalCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public long UpdateShippingStatusApprove(InputApproveShippingStatus inputApproveShippingStatus);
        public long UpdateShippingStatusCancel(InputCancelShippingStatus inputCancelShippingStatus);
    }
}
