namespace apiEstudo.Domain.DTOs
{
    public class BrandDTO : IBaseDTO<BrandDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
