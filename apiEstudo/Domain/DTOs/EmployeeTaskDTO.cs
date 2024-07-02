using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace apiEstudo.Domain.DTOs
{
    public class EmployeeTaskDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
