using apiEstudo.Application.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace apiEstudo.Domain.Models
{
    public abstract class BaseEntry<T> where T : BaseEntry<T>
    {
        public int Id { get; protected set; }
        public DateTime? CreationDate { get; protected set; }
        public DateTime? ChangeDate { get; set; }

        public T SetCreationDate() 
        {
            CreationDate = DateTime.Now;
            return (T)this;
        }

        public T SetChangeDate() 
        {
            ChangeDate = DateTime.Now;
            return (T)this; 
        }
    }
}
