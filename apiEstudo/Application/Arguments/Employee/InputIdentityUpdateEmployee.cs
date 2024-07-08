using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateEmployee : BaseInputIdentityUpdate<InputUpdateEmployee>
    {
        public InputIdentityUpdateEmployee(int id, InputUpdateEmployee inputUpdate) : base(id, inputUpdate)
        { }
    }
}
