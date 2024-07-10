using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteShoppingItem : BaseInputIdentityDelete<InputIdentityDeleteShoppingItem>
    {
        public InputIdentityDeleteShoppingItem(int id) : base(id)
        { }
    }
}
