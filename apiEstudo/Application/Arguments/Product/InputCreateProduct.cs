using apiEstudo.Application.Arguments.Base;

namespace apiEstudo.Application.Arguments.Product
{
    public class InputCreateProduct : BaseInputCreate<InputCreateProduct>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
    }
}
