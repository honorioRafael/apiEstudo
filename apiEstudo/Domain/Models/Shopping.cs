using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>
    {
        #region Properties
        public double Value { get; private set; }
        public long EmployeeId { get; private set; }
        public long ShippingStatusId { get; private set; }

        #region Internal
        public virtual Employee Employee { get; private set; }
        public virtual ShippingStatus ShippingStatus { get; set; }
        #endregion

        #region External
        public virtual List<ShoppingItem>? ListShoppingItem { get; private set; }
        #endregion

        #endregion

        public Shopping(long employeeid, double value, long shippingStatusId, Employee employee, ShippingStatus shippingStatus)
        {
            EmployeeId = employeeid;
            Value = value;
            Employee = employee;
            ShippingStatusId = shippingStatusId;
            ShippingStatus = shippingStatus;
        }

        public Shopping() { }


    }
}
