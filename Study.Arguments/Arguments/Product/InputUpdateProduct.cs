using Study.Arguments.Arguments.Base;

namespace Study.Arguments.Arguments
{
    public class InputUpdateProduct : BaseInputUpdate<InputUpdateProduct>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }
    }
}
