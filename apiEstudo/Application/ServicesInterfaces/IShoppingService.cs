using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public long UpdateShippingStatusApprove(InputApproveShippingStatus inputApproveShippingStatus);
        public long UpdateShippingStatusCancel(InputCancelShippingStatus inputCancelShippingStatus);
    }
}
