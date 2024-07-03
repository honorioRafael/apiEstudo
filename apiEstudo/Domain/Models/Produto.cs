using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class Produto : BaseEntry<Produto>
    {

        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public int MarcaId { get; private set; }
        public virtual Marca Marca { get; private set; }

        public Produto() { }
        public Produto(string nome, int quantidade, int marcaId)
        {
            Nome = nome;
            Quantidade = quantidade;
            MarcaId = marcaId;
        }
        public Produto(string nome, int quantidade, int marcaId, Marca marca)
        {
            Nome = nome;
            Quantidade = quantidade;
            MarcaId = marcaId;
            Marca = marca;
        }
        
        public static implicit operator ProdutoDTO(Produto produto)
        {
            return produto == null ? default : new ProdutoDTO { Nome = produto.Nome, Quantidade = produto.Quantidade, Marca = produto.Marca };
        }
    }
}
