using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteUser : BaseInputIdentityDelete<InputIdentityDeleteUser>
    {
        public InputIdentityDeleteUser(int id) : base(id)
        { }
    }
}
