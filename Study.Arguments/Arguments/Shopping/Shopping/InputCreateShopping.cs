using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputCreateShopping : BaseInputCreate<InputCreateShopping>
    {
        public long EmployeeId { get; set; }
        public double Value { get; set; }
        public List<InputCreateShoppingItem> CreatedItens { get; set; }

        public InputCreateShopping(long employeeId, double value, List<InputCreateShoppingItem> createdItens)
        {
            EmployeeId = employeeId;
            Value = value;
            CreatedItens = createdItens;
        }
    }
}
