namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateUser : BaseInputIdentityUpdate<InputUpdateUser>
    {
        public InputIdentityUpdateUser(int id, InputUpdateUser inputUpdate) : base(id, inputUpdate)
        { }
    }
}
