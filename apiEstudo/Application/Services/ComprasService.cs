using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ComprasService : BaseService<Compras, ComprasDTO>, IComprasService
    {
        private readonly IComprasRepository _comprasRepository;
        public ComprasService(IComprasRepository contextInterface) : base(contextInterface)
        {
            _comprasRepository = contextInterface;
        }

        public bool Create(ComprasViewModel view)
        {
            if (view == null) return false;
            var Entity = new Compras(view);
            _comprasRepository.Create(Entity);

            return true;
        }
    }
}
