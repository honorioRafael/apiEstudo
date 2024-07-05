using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Shopping : BaseEntry<Shopping>, IBaseModel<Shopping>
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
        
        public static implicit operator ShoppingDTO(Shopping compra)
        {
            return compra == null ? default : new ShoppingDTO {               
                Id = compra.Id,
                Employee = (EmployeeDTOSimplified)compra.Employee,
                Product = (ProductDTOSimplified)compra.Product,
                Value = compra.Value,
                TransationDate = compra.TransationDate
            };
        }
    }
}
