using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Models
{
    [Table("Task")]
    public class Task
    {
        public int id { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
    }
}
