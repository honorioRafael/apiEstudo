using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ComprasService : BaseService<Compras, IComprasRepository, ComprasDTO>, IComprasService
    {
        public ComprasService(IComprasRepository contextInterface) : base(contextInterface)
        { }

        public bool Create(ComprasViewModel view)
        {
            if (view == null) return false;
            var Entity = new Compras(view.EmployeeId, view.ProductId, view.Value, DateTime.Now, null, null);
            _repository.Create(Entity);

            return true;
        }
    }
}
