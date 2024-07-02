using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.DTOs
{
    public class ComprasDTO
    {
        /*public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string Produto { get; set; }*/
        public Produto Produto { get; set; }
        public Employee Employee { get; set; }
        public DateTime Data_compra { get; set; }
    }
}
