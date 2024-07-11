namespace apiEstudo.Application.Arguments
{
    public class BaseOutput<TOutput> where TOutput : BaseOutput<TOutput>
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? ChangeDate { get; set; }

        public virtual TOutput LoadInternalData(int id, DateTime? creationDate, DateTime? changeDate)
        {
            Id = id;
            CreationDate = creationDate;
            ChangeDate = changeDate;

            return (TOutput)this;
        }
    }

    public class BaseOutput_0 : BaseOutput<BaseOutput_0> { }
}