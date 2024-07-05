using apiEstudo.Application.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace apiEstudo.Domain.Models
{
    public abstract class BaseEntry<T> where T : BaseEntry<T>
    {
        public int Id { get; protected set; }        
        //public DateTime CreationDate { get; private set; }
        //public DateTime? ChangeDate { get; private set; }
    }
}
