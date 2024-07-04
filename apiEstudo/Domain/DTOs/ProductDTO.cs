namespace apiEstudo.Domain.DTOs
{
    public class ProductDTO : IBaseDTO<ProductDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public MarcaDTO Brand { get; set; }
    }

    public class ProductDTOSimplified
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
