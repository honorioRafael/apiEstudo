using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateBrand : BaseInputCreate<InputCreateBrand>
    {
        public string Name { get; set; }
    }
}
