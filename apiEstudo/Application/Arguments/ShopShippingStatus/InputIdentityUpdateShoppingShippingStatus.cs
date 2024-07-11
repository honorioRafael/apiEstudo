namespace apiEstudo.Application.Arguments
{
    public class InputIdentityUpdateShoppingShippingStatus //: BaseInputIdentityUpdate<InputUpdateShoppingShippingStatus>
    {
        public int Id { get; set; }
        public InputIdentityUpdateShoppingShippingStatus()
        {

        }
        public InputIdentityUpdateShoppingShippingStatus(int id) //: base(id, inputUpdate)
        {
            Id = id;
        }
    }
}
