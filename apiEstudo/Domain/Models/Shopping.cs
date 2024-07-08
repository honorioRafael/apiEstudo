using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>
    {
        public int EmployeeId { get; private set; }
        public double Value { get; private set; }
        public virtual Employee Employee { get; private set; }
        public virtual List<ShoppingList>? Products { get; private set; }

        public Shopping() { }

        public Shopping(int employeeid, List<ShoppingList>? products, double value, Employee employee)
        {
            EmployeeId = employeeid;
            Value = value;
            Employee = employee;
            Products = products;
        }

        public static implicit operator OutputShopping(Shopping shop)
        {
            return shop == null ? default : new OutputShopping(shop.Value, shop.Employee, (from item in shop.Products select (OutputShoppingList)item).ToList()).LoadInternalData(shop.Id, shop.CreationDate, shop.ChangeDate);
        }
    }
}
