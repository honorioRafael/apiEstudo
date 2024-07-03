using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.DTOs
{
    public class ComprasDTO
    {
        public int Id { get; set; }
        public ProdutoDTOSimplified Produto { get; set; }
        public EmployeeDTOSimplified Employee { get; set; }
        public double Valor { get; set; }
        public DateTime Data_compra { get; set; }
    }
}
