namespace apiEstudo.Application.Arguments
{
    public class BaseInputIdentityDelete<TInputInputIdentityDelete> where TInputInputIdentityDelete : BaseInputIdentityDelete<TInputInputIdentityDelete>
    {
        public int Id { get; set; }

        public BaseInputIdentityDelete(int id)
        {
            Id = id;
        }
    }

    public class InputIdentityDelete_0 : BaseInputIdentityDelete<InputIdentityDelete_0>
    {
        public InputIdentityDelete_0(int id) : base(id)
        {
        }
    }
}