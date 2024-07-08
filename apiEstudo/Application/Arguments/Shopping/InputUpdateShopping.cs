using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateShopping : BaseInputUpdate<InputUpdateShopping>
    {
        public int EmployeeId { get; set; }
        public double Value { get; set; }
    }
}
