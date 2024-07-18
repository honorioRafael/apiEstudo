using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputIdentityUpdateEmployee : BaseInputIdentityUpdate<InputUpdateEmployee>
    {
        public InputIdentityUpdateEmployee(long id, InputUpdateEmployee inputUpdate) : base(id, inputUpdate)
        { }
    }
}
