using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeService : BaseService_2<Employee, IEmployeeRepository, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTaskRepository employeeTaskRepository) : base(employeeRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public override List<int> UpdateMultiple(List<InputIdentityUpdateEmployee> listInputIdentityUpdateEmployee)
        {
            if (listInputIdentityUpdateEmployee.Count == 0)
                throw new ArgumentNullException();
            if (listInputIdentityUpdateEmployee.Any(x => x.InputUpdate.Age < 0))
                throw new InvalidArgumentException("Idade inválida!");
            List<EmployeeTask>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputIdentityUpdateEmployee select i.InputUpdate.TaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Há um ID de Tarefa inválido na lista de atualização!");                

            List<Employee>? EmployeesToBeUpdated = GetListByListId((from i in listInputIdentityUpdateEmployee select i.Id).ToList());
            if (EmployeesToBeUpdated == null || EmployeesToBeUpdated.Count == 0)
                throw new NotFoundException("Employee ID não localizado!");

            var employeesToUpdate = InternalUpdate(listInputIdentityUpdateEmployee, EmployeesToBeUpdated);
            return _repository.UpdateMultiple(employeesToUpdate);
        }

        public override List<int> CreateMultiple(List<InputCreateEmployee> listInputCreate)
        {
            if (listInputCreate.Count == 0)
                throw new ArgumentNullException();
            
            List<EmployeeTask>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputCreate select i.EmployeeTaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Employee Task ID inválido!");
            if (listInputCreate.Any(x => x.Age < 0))
                throw new InvalidArgumentException("Idade inválida!");

            var employeesToCreate = InternalCreate(listInputCreate);
            return _repository.CreateMultiple(employeesToCreate);            
        }
    }
}
