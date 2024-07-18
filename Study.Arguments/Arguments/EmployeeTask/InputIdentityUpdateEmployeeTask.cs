namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateEmployeeTask : BaseInputIdentityUpdate<InputUpdateEmployeeTask>
    {
        public InputIdentityUpdateEmployeeTask(long id, InputUpdateEmployeeTask inputUpdate) : base(id, inputUpdate)
        { }
    }
}
