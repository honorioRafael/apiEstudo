using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiEstudo.Domain.Model
{
    /*
        Table para indicar o nome da tabela. Caso na tabela esteja diferente da classe, inserir o da tabela entre ""
     */
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int id { get; private set; }
        public string? name { get; private set; }
        public int age { get; private set; }
        public int taskId { get; private set; }

        public Employee(string _name, int _age)
        {
            name = _name ?? throw new ArgumentException(nameof(_name));
            age = _age;
        }

        public Employee()
        {
        }
    }
}
