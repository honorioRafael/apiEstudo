using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateEmployeeTask : BaseInputIdentityUpdate<InputUpdateEmployeeTask>
    {
        public InputIdentityUpdateEmployeeTask(int id, InputUpdateEmployeeTask inputUpdate) : base(id, inputUpdate)
        { }
    }
}
