using System.ComponentModel.DataAnnotations;

namespace apiEstudo.Domain.Models
{
    public abstract class BaseEntry<T> where T : BaseEntry<T>
    {
        public int Id { get; private set; }
    }
}
