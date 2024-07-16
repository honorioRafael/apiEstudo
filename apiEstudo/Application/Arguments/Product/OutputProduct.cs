namespace apiEstudo.Application.Arguments
{
    public class OutputProduct : BaseOutput<OutputProduct>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }
        public OutputBrand Brand { get; set; }

        public OutputProduct()
        { }

        public OutputProduct(string name, int quantity, long brandId, OutputBrand brand)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
            Brand = brand;
        }
    }
}
