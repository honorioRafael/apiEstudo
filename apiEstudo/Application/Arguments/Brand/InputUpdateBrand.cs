using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateBrand : BaseInputUpdate<InputUpdateBrand>
    {
        public string Name { get; set; }
    }
}