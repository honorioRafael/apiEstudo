using Study.Arguments.Arguments;

namespace Study.Domain.Interface.Service
{
    public interface IShoppingService : IBaseService<InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public List<long> UpdateShippingStatusApprove(List<InputApproveShippingStatus> listInputApproveShippingStatus);
        public List<long> UpdateShippingStatusCancel(List<InputCancelShippingStatus> listInputCancelShippingStatus);
    }
}
