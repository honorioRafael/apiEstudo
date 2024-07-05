namespace apiEstudo.Application.Arguments
{
    public class BaseOutput<TOutput> where TOutput : BaseOutput<TOutput>
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual TOutput LoadInternalData(int id, DateTime? creationDate, DateTime? changeDate)
        {
            Id = id;
            CreationDate = creationDate;
            ChangeDate = changeDate;

            return (TOutput)this;
        }
    }
}