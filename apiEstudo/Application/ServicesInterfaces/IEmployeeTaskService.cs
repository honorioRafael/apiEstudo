using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IEmployeeTaskService : IBaseService<EmployeeTask, EmployeeTaskDTO>
    {
        public bool Update(int id, EmployeeTaskViewModel view);
        public bool Create(EmployeeTaskViewModel view);
    }
}
