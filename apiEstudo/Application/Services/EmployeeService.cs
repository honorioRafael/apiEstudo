using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeService : BaseService<Employee, IEmployeeRepository, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTaskRepository employeeTaskRepository) : base(employeeRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public override int Update(InputIdentityUpdateEmployee inputIdentityUpdateEmployee)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdateEmployee.Id);
            if (OriginalItem == null)
                throw new NotFoundException();
            if (_employeeTaskRepository.Get(inputIdentityUpdateEmployee.InputUpdate.TaskId) == null)
                throw new NotFoundException("Employee Task ID inválido!");
            if (inputIdentityUpdateEmployee.InputUpdate.Age < 0)
                throw new InvalidArgumentException("Idade inválida!");

            return _repository.Update(new Employee(inputIdentityUpdateEmployee.InputUpdate.Name,
                inputIdentityUpdateEmployee.InputUpdate.Age,
                inputIdentityUpdateEmployee.InputUpdate.TaskId, null).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }

        public override int Create(InputCreateEmployee inputCreateEmployee)
        {
            if (inputCreateEmployee == null)
                throw new ArgumentNullException();
            if (_employeeTaskRepository.Get(inputCreateEmployee.TaskId) == null)
                throw new NotFoundException("Employee Task ID inválido!");
            if (inputCreateEmployee.Age < 0)
                throw new InvalidArgumentException("Idade inválida!");

            return _repository.Create(inputCreateEmployee);
            // _repository.Create(new Employee(inputCreateEmployee.Name, inputCreateEmployee.Age, inputCreateEmployee.TaskId, null).SetCreationDate());
        }
    }
}
