using apiEstudo.Domain.DTOs;

namespace apiEstudo.Domain.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<EmployeeDTO>? Get();
        EmployeeDTO? Get(int id);
        EmployeeDTO? Get(string id);
    }
}
