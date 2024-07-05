using apiEstudo.Application.ViewModel.BrandViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBrandService : IBaseService<Brand, BrandDTO>
    {
        public bool Create(BrandCreateViewModel view);
    }
}
