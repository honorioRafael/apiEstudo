namespace apiEstudo.Application.Arguments
{
    public class OutputShippingStatus //: BaseOutput<OutputShippingStatus>
    {
        public string Description { get; set; }

        public OutputShippingStatus()
        { }

        public OutputShippingStatus(string description)
        {
            Description = description;
        }
    }
}
