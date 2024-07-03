using apiEstudo.Application.ViewModel;
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

        public void UpdateProduto(ProdutoViewModel produtoView)
        {
            Nome = produtoView.Nome;
            Quantidade = produtoView.Quantidade;
            MarcaId = produtoView.MarcaId;
        }

        public static implicit operator ProdutoDTOSimplified(Produto produto)
        {
            return produto == null ? default : new ProdutoDTOSimplified { Id = produto.Id, Nome = produto.Nome };
        }

        public static implicit operator ProdutoDTO(Produto produto)
        {
            return produto == null ? default : new ProdutoDTO { Id = produto.Id, Nome = produto.Nome, Quantidade = produto.Quantidade, Marca = produto.Marca };
        }
    }
}
