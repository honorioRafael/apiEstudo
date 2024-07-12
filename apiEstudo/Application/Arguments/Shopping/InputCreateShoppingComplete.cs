using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingComplete : BaseInputCreateComplete<InputCreateShopping, InputInternalCreateShopping>
    {
        public InputCreateShoppingComplete(InputCreateShopping inputCreate, InputInternalCreateShopping inputInternalCreate) : base(inputCreate, inputInternalCreate)
        { }
    }
}
