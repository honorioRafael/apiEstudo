namespace Study.Arguments.Arguments
{
    public class BaseInputIdentityDelete<TInputInputIdentityDelete> where TInputInputIdentityDelete : BaseInputIdentityDelete<TInputInputIdentityDelete>
    {
        public long Id { get; set; }

        public BaseInputIdentityDelete() { }

        public BaseInputIdentityDelete(long id)
        {
            Id = id;
        }
    }

    public class BaseInputIdentityDelete_0 : BaseInputIdentityDelete<BaseInputIdentityDelete_0> { }
}