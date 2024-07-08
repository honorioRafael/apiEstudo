using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments
{
    public class InputUpdateProduct : BaseInputUpdate<InputUpdateProduct>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
