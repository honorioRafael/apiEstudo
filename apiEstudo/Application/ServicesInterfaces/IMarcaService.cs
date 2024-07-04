using apiEstudo.Application.ViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IMarcaService : IBaseService<Marca, MarcaDTO>
    {
        public bool Create(MarcaViewModel view);
    }
}
