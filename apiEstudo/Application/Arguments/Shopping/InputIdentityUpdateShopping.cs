using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateShopping : BaseInputIdentityUpdate<InputUpdateShopping>
    {
        public InputIdentityUpdateShopping(int id, InputUpdateShopping inputUpdate) : base(id, inputUpdate)
        {
        }
    }
}
