namespace apiEstudo.Domain.Models
{
    public abstract class BaseEntry<TEntry> where TEntry : BaseEntry<TEntry>
    {
        public int Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime? ChangeDate { get; set; }

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
