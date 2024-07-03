using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Domain.Models
{
    public class Compras : BaseEntry<Compras>
    {
        public int Employeeid { get; private set; }
        public int Produtoid { get; private set; }
        public double Valor { get; private set; }
        public DateTime Data_compra { get; private set; }
        public virtual Employee Employee { get; private set; }
        public virtual Produto Produto { get; private set; }

        public Compras() { }

        public Compras(int employeeid, int produtoid, double valor)
        {
            Employeeid = employeeid;
            Produtoid = produtoid;
            Valor = valor;
            Data_compra = DateTime.Now; 
        }
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
                Id = compra.Id,
                Employee = new () {
                    Name = compra.Employee.Name
                },
                Produto = new () {
                    Nome = compra.Produto.Nome,
                    Quantidade = compra.Produto.Quantidade
                },
                Valor = compra.Valor,
                Data_compra = compra.Data_compra
            };
        }
    }
}
