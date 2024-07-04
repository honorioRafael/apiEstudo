namespace apiEstudo.Domain.DTOs
{
    public class MarcaDTO : IBaseDTO<MarcaDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
