using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class MarcaService : BaseService<Marca, IMarcaRepository, MarcaDTO>, IMarcaService
    {
        public MarcaService(IMarcaRepository contextInterface) : base(contextInterface)
        { }

        public bool Create(MarcaViewModel view)
        {
            if (view == null) return false;

            var entity = new Marca(view.Name);
            _repository.Create(entity);
            return true;
        }
    }
}
