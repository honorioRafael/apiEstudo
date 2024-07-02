using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Compras : BaseEntry<Compras>
    {
        public int Employeeid { get; private set; }
        public int Produtoid { get; private set; }
        public DateTime Data_compra { get; private set; }
        public virtual Employee Employee { get; private set; }
        public virtual Produto Produto { get; private set; }

        public Compras() { }

        public Compras(int employeeid, int produtoid, DateTime data_compra, Employee employee, Produto produto)
        {
            Employeeid = employeeid;
            Produtoid = produtoid;
            Data_compra = data_compra;
            Employee = employee;
            Produto = produto;
        }

        public static implicit operator ComprasDTO(Compras compra)
        {
            return compra == null ? default : new ComprasDTO {
                //EmployeeId = compra.Employee.Id, EmployeeName = compra.Employee.Name, Produto = compra.Produto.Nome, Data_compra = compra.Data_compra 
                Employee = compra.Employee,
                Produto = compra.Produto,
                Data_compra = compra.Data_compra
            };
        }
    }
}
