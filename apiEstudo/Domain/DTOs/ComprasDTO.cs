using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.DTOs
{
    public class ComprasDTO
    {
        /*public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string Produto { get; set; }*/
        public int Id { get; set; }
        public ProdutoDTO Produto { get; set; }
        public EmployeeDTO Employee { get; set; }
        public double Valor { get; set; }
        public DateTime Data_compra { get; set; }
    }
}
