using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.DTOs
{
    public class ShoppingDTO : IBaseDTO<ShoppingDTO>
    {
        public int Id { get; set; }
        public ProductDTOSimplified Product { get; set; }
        public EmployeeDTOSimplified Employee { get; set; }
        public double Value { get; set; }
        public DateTime TransationDate { get; set; }
    }
}
