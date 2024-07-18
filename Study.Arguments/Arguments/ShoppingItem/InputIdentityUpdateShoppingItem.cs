namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateShoppingItem : BaseInputIdentityUpdate<InputUpdateShoppingItem>
    {
        public InputIdentityUpdateShoppingItem(long id, InputUpdateShoppingItem inputUpdate) : base(id, inputUpdate)
        { }
    }
}
