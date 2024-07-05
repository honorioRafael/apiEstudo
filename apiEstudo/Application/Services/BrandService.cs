using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.BrandViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class BrandService : BaseService<Brand, IBrandRepository, BrandDTO>, IBrandService
    {
        public BrandService(IBrandRepository contextInterface) : base(contextInterface)
        { }

        public bool Create(BrandCreateViewModel view)
        {
            if (view == null) return false;

            var entity = new Brand(view.Name);
            _repository.Create(entity);
            return true;
        }
    }
}
