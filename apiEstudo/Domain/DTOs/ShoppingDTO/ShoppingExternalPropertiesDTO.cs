namespace apiEstudo.Domain.DTOs
{
    public class ShoppingExternalPropertiesDTO : BaseExternalPropertiesDTO<ShoppingExternalPropertiesDTO>
    {
        public long EmployeeId { get; set; }
        public double Value { get; set; }
        public ShoppingExternalPropertiesDTO() { }
    }
}
