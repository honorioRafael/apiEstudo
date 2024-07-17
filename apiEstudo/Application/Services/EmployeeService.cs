using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeService : BaseService<Employee, IEmployeeRepository, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTaskRepository employeeTaskRepository, IIdControlRepository idControlRepository) : base(employeeRepository, idControlRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public override List<long> CreateMultiple(List<InputCreateEmployee> listInputCreateEmployee)
        {
            if (listInputCreateEmployee.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeTaskDTO>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputCreateEmployee select i.EmployeeTaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Employee Task ID inválido!");
            if (listInputCreateEmployee.Any(x => x.Age < 0))
                throw new InvalidArgumentException("Há uma idade inválida na lista de atualização.");

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(Employee)), listInputCreateEmployee.Count);
            var id = idRange.FirstId;

            var employeesToCreate = (from inputCreateEmployee in listInputCreateEmployee
                                     select new EmployeeDTO().Create(id++, inputCreateEmployee)).ToList();
            return _repository.CreateMultiple(employeesToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateEmployee> listInputIdentityUpdateEmployee)
        {
            if (listInputIdentityUpdateEmployee.Count == 0)
                throw new ArgumentNullException();
            if (listInputIdentityUpdateEmployee.Any(x => x.InputUpdate.Age < 0))
                throw new InvalidArgumentException("Idade inválida!");

            List<EmployeeTaskDTO>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputIdentityUpdateEmployee select i.InputUpdate.EmployeeTaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Há um ID de Tarefa inválido na lista de atualização!");

            List<EmployeeDTO>? employeesToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateEmployee select i.Id).ToList());
            if (employeesToBeUpdated == null || employeesToBeUpdated.Count != listInputIdentityUpdateEmployee.Count)
                throw new NotFoundException("Há um ID de Funcionário inválido na lista de atualização.");

            var updatedEmployees = (from inputIdentityUpdateEmployee in listInputIdentityUpdateEmployee
                                    let inputUpdateEmployee = inputIdentityUpdateEmployee.InputUpdate
                                    from employeeToUpdate in employeesToBeUpdated
                                    where employeeToUpdate.InternalPropertiesDTO.Id == inputIdentityUpdateEmployee.Id
                                    select employeeToUpdate.Update(inputUpdateEmployee)).ToList();
            return _repository.UpdateMultiple(updatedEmployees);
        }
    }
}
