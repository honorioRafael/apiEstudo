using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>
    {
        public int EmployeeId { get; private set; }
        public int ProductId { get; private set; }
        public double Value { get; private set; }
        public DateTime TransationDate { get; private set; }
        public virtual Employee Employee { get; private set; }
        public virtual Product Product { get; private set; }

        public Shopping() { }

        public Shopping(int employeeid, int productid, double value, DateTime transationDate, Employee employee, Product product)
        {
            EmployeeId = employeeid;
            ProductId = productid;
            TransationDate = transationDate;
            Value = value;
            Employee = employee;
            Product = product;
        }

        public static implicit operator OutputShopping(Shopping shop)
        {
            return shop == null ? default : new OutputShopping(shop.Value, shop.TransationDate, shop.Employee, shop.Product).LoadInternalData(shop.Id, shop.CreationDate, shop.ChangeDate);
        }
    }
}
