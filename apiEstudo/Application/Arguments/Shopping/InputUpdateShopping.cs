using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateShopping : BaseInputUpdate<InputUpdateShopping>
    {
        public int EmployeeId { get; set; }
        public double Value { get; set; }


    }
}
