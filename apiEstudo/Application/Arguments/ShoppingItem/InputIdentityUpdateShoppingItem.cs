using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateShoppingItem : BaseInputIdentityUpdate<InputUpdateShoppingItem>
    {
        public InputIdentityUpdateShoppingItem(int id, InputUpdateShoppingItem inputUpdate) : base(id, inputUpdate)
        { }
    }
}
