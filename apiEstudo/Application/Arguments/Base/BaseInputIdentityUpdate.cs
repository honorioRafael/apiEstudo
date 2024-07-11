namespace apiEstudo.Application.Arguments
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

    public class InputIdentityUpdate_0 : BaseInputIdentityUpdate<InputUpdate_0>
    {
        public InputIdentityUpdate_0(int id, InputUpdate_0 inputUpdate) : base(id, inputUpdate)
        {
        }
    }
}