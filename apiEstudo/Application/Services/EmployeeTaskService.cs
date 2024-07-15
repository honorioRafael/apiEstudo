using apiEstudo.Application.Arguments;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application
{
    public class EmployeeTaskService : BaseService_2<EmployeeTask, IEmployeeTaskRepository, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface) : base(contextInterface)
        { }

        public override List<int> CreateMultiple(List<InputCreateEmployeeTask> listInputCreateEmployeeTask)
        {
            if (listInputCreateEmployeeTask.Count == 0)
                throw new ArgumentNullException();

            var employeeTaskToCreate = InternalCreate(listInputCreateEmployeeTask);
            return _repository.CreateMultiple(employeeTaskToCreate);// _repository.Create(new EmployeeTask(inputCreateEmployeeTask.Name, inputCreateEmployeeTask.Description));
        }

        public override List<int> UpdateMultiple(List<InputIdentityUpdateEmployeeTask> listInputIdentityUpdate)
        {
            if (listInputIdentityUpdate.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeTask> EmployeeTasksToBeUpdated = GetListByListId((from i in listInputIdentityUpdate select i.Id).ToList());
            if (EmployeeTasksToBeUpdated.Count == 0)
                throw new NotFoundException("EmployeeTask ID não localizado!");

            var employeeTasksToUpdate = InternalUpdate(listInputIdentityUpdate, EmployeeTasksToBeUpdated);
            return _repository.UpdateMultiple(employeeTasksToUpdate);
        }
    }
}
