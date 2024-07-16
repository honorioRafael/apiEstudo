namespace apiEstudo.Domain.Models
{
    public abstract class BaseEntry<TEntry> where TEntry : BaseEntry<TEntry>
    {
        public long Id { get; protected set; }
        public virtual DateTime CreationDate { get; protected set; }
        public virtual DateTime? ChangeDate { get; set; }

        public TEntry LoadInternalData(long id, DateTime creationDate, DateTime? changeDate)
        {
            Id = id;
            CreationDate = creationDate;
            ChangeDate = changeDate;

            return (TEntry)this;
        }

        public TEntry SetCreationDate()
        {
            CreationDate = DateTime.Now;
            return (TEntry)this;
        }

        public TEntry SetChangeDate()
        {
            ChangeDate = DateTime.Now;
            return (TEntry)this;
        }
    }
}
