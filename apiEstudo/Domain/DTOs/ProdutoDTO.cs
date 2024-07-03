﻿namespace apiEstudo.Domain.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public MarcaDTO Marca { get; set; }
    }

    public class ProdutoDTOSimplified
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
