namespace apiEstudo.Application.Arguments
{
    public class BaseInputIdentityUpdate<TInputUpdate> where TInputUpdate : BaseInputUpdate<TInputUpdate>
    {
        public int Id { get; set; }
        public virtual TInputUpdate? InputUpdate { get; set; }

        public BaseInputIdentityUpdate(int id, TInputUpdate? inputUpdate)
        {
            Id = id;
            InputUpdate = inputUpdate;
        }
    }

    public class BaseInputIdentityUpdate_0 : BaseInputIdentityUpdate<BaseInputUpdate_0>
    {
        public BaseInputIdentityUpdate_0(int id, BaseInputUpdate_0 inputUpdate) : base(id, inputUpdate) { }
    }
}