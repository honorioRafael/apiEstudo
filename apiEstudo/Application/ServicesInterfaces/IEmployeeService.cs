using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IEmployeeService : IBaseService<Employee, EmployeeDTO>
    {
        public bool Update(int id, EmployeeViewModel view);
    }
}
