namespace apiEstudo.Application.Arguments
{
    public class BaseInputIdentityDelete<TInputInputIdentityDelete> where TInputInputIdentityDelete : BaseInputIdentityDelete<TInputInputIdentityDelete>
    {
        public int Id { get; set; }

        public BaseInputIdentityDelete() { }

        public BaseInputIdentityDelete(int id)
        {
            Id = id;
        }
    }

    public class BaseInputIdentityDelete_0 : BaseInputIdentityDelete<BaseInputIdentityDelete_0> { }
}