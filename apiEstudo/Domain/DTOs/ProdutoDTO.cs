namespace apiEstudo.Domain.DTOs
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public MarcaDTO Marca { get; set; }
    }
}
