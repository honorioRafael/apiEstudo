using apiEstudo.Application.Arguments;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application
{
    public class EmployeeTaskService : BaseService<EmployeeTask, IEmployeeTaskRepository, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public override List<long> CreateMultiple(List<InputCreateEmployeeTask> listInputCreateEmployeeTask)
        {
            if (listInputCreateEmployeeTask.Count == 0)
                throw new ArgumentNullException();

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(EmployeeTask)), listInputCreateEmployeeTask.Count);
            var id = idRange.FirstId;

            var employeeTaskToCreate = (from inputCreateEmployeeTask in listInputCreateEmployeeTask
                                        select new EmployeeTaskDTO().Create(id++, inputCreateEmployeeTask)).ToList();
            return _repository.CreateMultiple(employeeTaskToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateEmployeeTask> listInputIdentityUpdateEmployeeTask)
        {
            if (listInputIdentityUpdateEmployeeTask.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeTaskDTO> employeeTasksToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateEmployeeTask select i.Id).ToList());
            if (employeeTasksToBeUpdated.Count == 0)
                throw new NotFoundException("EmployeeTask ID não localizado!");

            var updatedTasks = (from inputIdentityUpdateEmployeeTask in listInputIdentityUpdateEmployeeTask
                                let inputUpdateEmployeeTask = inputIdentityUpdateEmployeeTask.InputUpdate
                                from employeeTaskToUpdate in employeeTasksToBeUpdated
                                select employeeTaskToUpdate.Update(inputUpdateEmployeeTask)).ToList();
            return _repository.UpdateMultiple(updatedTasks);
        }
    }
}
