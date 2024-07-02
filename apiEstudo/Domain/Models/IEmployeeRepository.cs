using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;

namespace apiEstudo.Domain.Model
{
    public interface IEmployeeRepository //: IBaseRepository<Employee>
    {
        void Add(Employee employee);
        //List<EmployeeDTO>? Get();
        //EmployeeDTO? Get(int id);
        //EmployeeDTO? Get(string id);
    }
}
