namespace apiEstudo.Application.Arguments
{
    public class OutputBrand : BaseOutput<OutputBrand>
    {
        public string Name { get; set; }
        //public List<OutputProduct> ListProduct { get; set; }

        public OutputBrand() { }

        public OutputBrand(string name/*, List<OutputProduct> listProduct*/)
        {
            Name = name;
            //ListProduct = listProduct;
        }
    }
}