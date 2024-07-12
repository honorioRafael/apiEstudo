using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>
    {
        #region Properties
        public double Value { get; private set; }
        public int EmployeeId { get; private set; }
        public int ShippingStatusId { get; private set; }

        #region Internal
        public virtual Employee Employee { get; private set; }
        public virtual ShippingStatus ShippingStatus { get; set; }
        #endregion

        #region External
        public virtual List<ShoppingItem>? ListShoppingItem { get; private set; }
        #endregion

        #endregion

        public Shopping(int employeeid, double value, int shippingStatusId, Employee employee, ShippingStatus shippingStatus)
        {
            EmployeeId = employeeid;
            Value = value;
            Employee = employee;
            ShippingStatusId = shippingStatusId;
            ShippingStatus = shippingStatus;
        }

        public Shopping() { }

        public static implicit operator OutputShopping(Shopping shop)
        {
            return shop == null ? default : new OutputShopping(shop.Value, shop.Employee, (from item in shop.ListShoppingItem select (OutputShoppingItem)item).ToList(), shop.ShippingStatus).LoadInternalData(shop.Id, shop.CreationDate, shop.ChangeDate);
        }
    }
}
