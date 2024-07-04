using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Marca : BaseEntry<Marca>, IBaseModel<Marca>
    {
        public string Name { get; set; }

        public Marca(string name)
        {
            Name = name;
        }

        public static implicit operator MarcaDTO(Marca marca)
        {
            return marca == null ? default : new MarcaDTO { Id = marca.Id, Name = marca.Name };
        }
    }   
}
