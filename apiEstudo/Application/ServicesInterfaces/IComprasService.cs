using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IComprasService : IBaseService<Compras, ComprasDTO>
    {
        public bool Create(ComprasViewModel view);
    }
}
