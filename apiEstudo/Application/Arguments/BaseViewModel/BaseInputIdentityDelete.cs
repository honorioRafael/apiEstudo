namespace apiEstudo.Application.Arguments.BaseViewModel
{
    public class BaseInputIdentityDelete<TInputInputIdentityDelete> where TInputInputIdentityDelete : BaseInputIdentityDelete<TInputInputIdentityDelete>
    {
        public int Id { get; set; }

        public BaseInputIdentityDelete(int id)
        {
            Id = id;
        }
    }
}