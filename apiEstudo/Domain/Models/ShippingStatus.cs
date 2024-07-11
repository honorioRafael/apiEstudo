using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.Models
{
    public class ShippingStatus : BaseEntry<ShippingStatus>
    {
        public string Description { get; set; }
        public virtual List<Shopping> ListShoppings { get; set; }

        public ShippingStatus()
        { }

        public ShippingStatus(string description, List<Shopping> listShoppings)
        {
            Description = description;
            ListShoppings = listShoppings;
        }

        public static implicit operator OutputShippingStatus(ShippingStatus shippingStatus)
        {
            return shippingStatus == null ? default : new OutputShippingStatus(shippingStatus.Description);
        }
    }
}
