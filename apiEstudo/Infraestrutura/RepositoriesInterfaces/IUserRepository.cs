﻿using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository<User, UserDTO>
    { }
}
