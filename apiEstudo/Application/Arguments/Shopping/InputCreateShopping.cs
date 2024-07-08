using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateShopping : BaseInputCreate<InputCreateShopping>
    {
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
    }
}
