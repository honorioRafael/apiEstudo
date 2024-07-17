namespace apiEstudo.Domain.DTOs
{
    public class ShoppingExternalPropertiesDTO : BaseExternalPropertiesDTO<ShoppingExternalPropertiesDTO>
    {
        public long EmployeeId { get; set; }
        public double Value { get; set; }
        public ShoppingExternalPropertiesDTO() { }

        public ShoppingExternalPropertiesDTO(long employeeId, double value)
        {
            EmployeeId = employeeId;
            Value = value;
        }
    }
}
