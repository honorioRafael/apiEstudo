namespace apiEstudo.Domain.Models
{
    public interface IBaseRepository<T>
    {
        public List<T>? Get(IEnumerable<T> table);
        public List<T>? Get(IEnumerable<T> table, Func<T, bool> filter);
    }
}
