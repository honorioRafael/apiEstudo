using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class MarcaService : BaseService<Marca, MarcaDTO>, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;
        public MarcaService(IMarcaRepository contextInterface) : base(contextInterface)
        {
            _marcaRepository = contextInterface;
        }

        public bool Create(MarcaViewModel view)
        {
            if (view == null) return false;

            var entity = new Marca(view);
            _marcaRepository.Create(entity);
            return true;
        }
    }
}
