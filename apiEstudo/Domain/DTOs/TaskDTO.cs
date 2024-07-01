using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace apiEstudo.Domain.DTOs
{
    public class TaskDTO
    {
        public string taskName { get; set; }
        public string taskDescription { get; set; }
    }
}
