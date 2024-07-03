using apiEstudo.Domain.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Marca : BaseEntry<Marca>
    {
        public string Nome { get; set; }

        public Marca(string nome)
        {
            Nome = nome;
        }

        public static implicit operator MarcaDTO(Marca marca)
        {
            return marca == null ? default : new MarcaDTO { Nome = marca.Nome };
        }
    }   
}
