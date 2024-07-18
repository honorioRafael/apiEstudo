using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputIdentityUpdateShoppingItem : BaseInputIdentityUpdate<InputUpdateShoppingItem>
    {
        public InputIdentityUpdateShoppingItem(long id, InputUpdateShoppingItem inputUpdate) : base(id, inputUpdate)
        { }
    }
}
