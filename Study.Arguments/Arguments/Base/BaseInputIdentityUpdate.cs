namespace Study.Arguments.Arguments
{
    public class BaseInputIdentityUpdate<TInputUpdate> where TInputUpdate : BaseInputUpdate<TInputUpdate>
    {
        public long Id { get; set; }
        public virtual TInputUpdate? InputUpdate { get; set; }

        public BaseInputIdentityUpdate(long id, TInputUpdate? inputUpdate)
        {
            Id = id;
            InputUpdate = inputUpdate;
        }
    }

    public class BaseInputIdentityUpdate_0 : BaseInputIdentityUpdate<BaseInputUpdate_0>
    {
        public BaseInputIdentityUpdate_0(long id, BaseInputUpdate_0 inputUpdate) : base(id, inputUpdate) { }
    }
}