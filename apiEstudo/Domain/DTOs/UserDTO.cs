using apiEstudo.Domain.Models;

namespace apiEstudo.Domain.DTOs
{
    public class UserDTO : IBaseDTO<UserDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
