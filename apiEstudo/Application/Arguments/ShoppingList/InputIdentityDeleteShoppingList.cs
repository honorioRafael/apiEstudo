using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteShoppingList : BaseInputIdentityDelete<InputIdentityDeleteShoppingList>
    {
        public InputIdentityDeleteShoppingList(int id) : base(id)
        { }
    }
}
