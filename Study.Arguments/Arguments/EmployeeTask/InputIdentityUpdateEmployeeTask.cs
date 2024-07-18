using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputIdentityUpdateEmployeeTask : BaseInputIdentityUpdate<InputUpdateEmployeeTask>
    {
        public InputIdentityUpdateEmployeeTask(long id, InputUpdateEmployeeTask inputUpdate) : base(id, inputUpdate)
        { }
    }
}
