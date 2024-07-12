using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateShoppingItemComplete : BaseInputCreateComplete<InputCreateShoppingItem, InputInternalCreateShoppingItem>
    {
        public InputCreateShoppingItemComplete(InputCreateShoppingItem inputCreate, InputInternalCreateShoppingItem inputInternalCreate) : base(inputCreate, inputInternalCreate)
        {
        }
    }
}