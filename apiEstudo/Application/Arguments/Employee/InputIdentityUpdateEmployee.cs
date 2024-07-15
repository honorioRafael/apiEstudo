namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateEmployee : BaseInputIdentityUpdate<InputUpdateEmployee>
    {
        public InputIdentityUpdateEmployee(long id, InputUpdateEmployee inputUpdate) : base(id, inputUpdate)
        { }
    }
}
