namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateUser : BaseInputIdentityUpdate<InputUpdateUser>
    {
        public InputIdentityUpdateUser(long id, InputUpdateUser inputUpdate) : base(id, inputUpdate)
        { }
    }
}
