using Study.Arguments.Arguments;
using Study.Arguments.CustomException;
using Study.Arguments.CustomFunction;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Base;

namespace Study.Application
{
    public class EmployeeTaskService : BaseService<IEmployeeTaskRepository, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public override List<long> CreateMultiple(List<InputCreateEmployeeTask> listInputCreateEmployeeTask)
        {
            if (listInputCreateEmployeeTask.Count == 0)
                throw new ArgumentNullException();

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId("EmployeeTask"), listInputCreateEmployeeTask.Count);
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
            if (employeeTasksToBeUpdated.Count != listInputIdentityUpdateEmployeeTask.Count)
                throw new NotFoundException("EmployeeTask ID não localizado!");

            var updatedTasks = (from inputIdentityUpdateEmployeeTask in listInputIdentityUpdateEmployeeTask
                                let inputUpdateEmployeeTask = inputIdentityUpdateEmployeeTask.InputUpdate
                                let employeeTaskToUpdate = (from j in employeeTasksToBeUpdated where j.InternalPropertiesDTO.Id == inputIdentityUpdateEmployeeTask.Id select j).FirstOrDefault()
                                select employeeTaskToUpdate.Update(inputUpdateEmployeeTask)).ToList();
            return _repository.UpdateMultiple(updatedTasks);
        }
    }
}
