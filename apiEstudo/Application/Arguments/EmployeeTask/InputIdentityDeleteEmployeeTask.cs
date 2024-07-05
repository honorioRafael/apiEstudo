using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteEmployeeTask : BaseInputIdentityDelete<InputIdentityDeleteEmployeeTask>
    {
        public InputIdentityDeleteEmployeeTask(int id) : base(id)
        { }
    }
}
