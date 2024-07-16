using apiEstudo.Application.Arguments;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    public class ShippingStatus : BaseEntry<ShippingStatus>
    {
        #region Properties
        #region Base Ignore
        [NotMapped]
        public override DateTime CreationDate { get => base.CreationDate; protected set => base.CreationDate = value; }
        [NotMapped]
        public override DateTime? ChangeDate { get => base.ChangeDate; set => base.ChangeDate = value; }
        #endregion

        public string Description { get; set; }

        public virtual List<Shopping> ListShoppings { get; set; }

        #endregion

        public ShippingStatus(string description, List<Shopping> listShoppings)
        {
            Description = description;
            ListShoppings = listShoppings;
        }
        public ShippingStatus()
        { }

        public static implicit operator OutputShippingStatus(ShippingStatus shippingStatus)
        {
            return shippingStatus == null ? default : new OutputShippingStatus(shippingStatus.Id, shippingStatus.Description);
        }
    }
}
