using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteProduct : BaseInputIdentityDelete<InputIdentityDeleteProduct>
    {
        public InputIdentityDeleteProduct(int id) : base(id)
        {
        }
    }
}
