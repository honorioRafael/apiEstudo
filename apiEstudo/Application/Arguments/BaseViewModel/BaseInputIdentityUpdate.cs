namespace apiEstudo.Application.Arguments.Base
{
    public class BaseInputIdentityUpdate<TInputUpdate> where TInputUpdate : BaseInputUpdate<TInputUpdate>
    {
        public int Id { get; set; }
        public TInputUpdate InputUpdate { get; set; }

        public BaseInputIdentityUpdate(int id, TInputUpdate inputUpdate)
        {
            Id = id;
            InputUpdate = inputUpdate;
        }
    }
}