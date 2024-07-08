using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateShoppingList : BaseInputIdentityUpdate<InputUpdateShoppingList>
    {
        public InputIdentityUpdateShoppingList(int id, InputUpdateShoppingList inputUpdate) : base(id, inputUpdate)
        { }
    }
}
