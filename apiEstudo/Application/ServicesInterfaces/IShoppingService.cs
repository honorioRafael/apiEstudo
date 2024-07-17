using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public List<long> UpdateShippingStatusApprove(List<InputApproveShippingStatus> listInputApproveShippingStatus);
        public List<long> UpdateShippingStatusCancel(List<InputCancelShippingStatus> listInputCancelShippingStatus);
    }
}
