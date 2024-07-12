﻿using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IProductRepository : IBaseRepository_2<Product, InputCreateProduct, InputUpdateProduct>
    {
    }
}
