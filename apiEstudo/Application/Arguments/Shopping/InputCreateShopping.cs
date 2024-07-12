namespace apiEstudo.Application.Arguments
{
    public class InputCreateShopping : BaseInputCreate<InputCreateShopping>
    {
        public int EmployeeId { get; set; }
        public double Value { get; set; }
        public int ShippingStatusId { get; private set; }
        public List<InputCreateShoppingItem> CreatedItens { get; set; }

        public InputCreateShopping(int employeeId, double value, List<InputCreateShoppingItem> createdItens)
        {
            EmployeeId = employeeId;
            Value = value;
            CreatedItens = createdItens;
            ShippingStatusId = 1;
        }
    }
}
