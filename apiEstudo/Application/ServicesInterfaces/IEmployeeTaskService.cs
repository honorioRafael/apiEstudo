using apiEstudo.Application.ViewModel.EmployeeTaskViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IEmployeeTaskService : IBaseService<EmployeeTask, EmployeeTaskDTO>
    {
        public bool Update(EmployeeTaskUpdateViewModel view);
        public bool Create(EmployeeTaskCreateViewModel view);
    }
}
