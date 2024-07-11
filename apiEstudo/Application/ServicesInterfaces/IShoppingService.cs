using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public long UpdateShippingStatus(int shippingStatusID, InputIdentityUpdateShoppingShippingStatus inputIdentityUpdateShopShippingStatus);
    }
}
