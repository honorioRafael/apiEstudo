using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace apiEstudo.Application.Services
{
    public class EmployeeService : BaseService<Employee, IEmployeeRepository, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        { }

        public override long Update(InputIdentityUpdateEmployee inputIdentityUpdateEmployee)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdateEmployee.Id);
            if(OriginalItem == null) throw new NotFoundException();
            return _repository.Update(new Employee(inputIdentityUpdateEmployee.InputUpdate.Name,
                inputIdentityUpdateEmployee.InputUpdate.Age,
                inputIdentityUpdateEmployee.InputUpdate.TaskId, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }

        public override long Create(InputCreateEmployee inputCreateEmployee)
        {
            if (inputCreateEmployee == null) throw new ArgumentNullException();
            return _repository.Create(new Employee(inputCreateEmployee.Name, inputCreateEmployee.Age, inputCreateEmployee.TaskId, null).SetCreationDate());
        }
    }
}
