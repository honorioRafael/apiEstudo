namespace apiEstudo.Application.Arguments.Product
{
    public class InputCreateProduct : BaseInputCreate<InputCreateProduct>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }
    }
}
