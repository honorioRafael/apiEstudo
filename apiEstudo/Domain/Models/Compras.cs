using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Compras : BaseEntry<Compras>, IBaseModel<Compras>
    {
        public int EmployeeId { get; private set; }
        public int ProductId { get; private set; }
        public double Value { get; private set; }
        public DateTime TransationDate { get; private set; }
        public virtual Employee Employee { get; private set; }
        public virtual Product Product { get; private set; }

        public Compras() { }

        public Compras(int employeeid, int productid, double value)
        {
            EmployeeId = employeeid;
            ProductId = productid;
            Value = value;
            TransationDate = DateTime.Now; 
        }
        public Compras(int employeeid, int productid, double value, DateTime transationDate, Employee employee, Product product)
        {
            EmployeeId = employeeid;
            ProductId = productid;
            TransationDate = transationDate;
            Value = value;
            Employee = employee;
            Product = product;       
        }
        
        public static implicit operator ComprasDTO(Compras compra)
        {
            return compra == null ? default : new ComprasDTO {               
                Id = compra.Id,
                Employee = (EmployeeDTOSimplified)compra.Employee,
                Product = (ProductDTOSimplified)compra.Product,
                Value = compra.Value,
                TransationDate = compra.TransationDate
            };
        }
    }
}
