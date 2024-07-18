namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateProduct : BaseInputIdentityUpdate<InputUpdateProduct>
    {
        public InputIdentityUpdateProduct(long id, InputUpdateProduct inputUpdate) : base(id, inputUpdate)
        {
        }
    }
}
