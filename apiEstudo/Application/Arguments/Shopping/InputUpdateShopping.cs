using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateShopping : BaseInputUpdate<InputUpdateShopping>
    {
        public int EmployeeId { get; set; }
        public double Value { get; set; }
        public List<InputCreateShoppingItem>? CreatedItens { get; set; }
        public List<InputIdentityUpdateShoppingItem>? UpdatedItens { get; set; }
        public List<InputIdentityDeleteShoppingItem>? DeletedItens { get; set; }
    }
}
