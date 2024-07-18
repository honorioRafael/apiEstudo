namespace Study.Domain.DTO
{
    public class ShoppingAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<ShoppingAuxiliaryPropertiesDTO>
    {
        public EmployeeDTO EmployeeDTO { get; set; }
        public ShippingStatusDTO ShippingStatusDTO { get; set; }

        public ShoppingAuxiliaryPropertiesDTO() { }

        public ShoppingAuxiliaryPropertiesDTO(EmployeeDTO employeeDTO, ShippingStatusDTO shippingStatusDTO)
        {
            EmployeeDTO = employeeDTO;
            ShippingStatusDTO = shippingStatusDTO;
        }
    }
}
