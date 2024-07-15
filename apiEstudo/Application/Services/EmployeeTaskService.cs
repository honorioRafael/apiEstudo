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

        public int Update(InputIdentityUpdateEmployeeTask inputIdentityUpdateEmployeeTask)
        {
            if (inputIdentityUpdateEmployeeTask == null)
                throw new ArgumentNullException();
         
            return base.Update(inputIdentityUpdateEmployeeTask);// _repository.Update(new EmployeeTask(inputIdentityUpdateEmployeeTask.InputUpdate.Name, inputIdentityUpdateEmployeeTask.InputUpdate.Description).LoadInternalData(originalEmployeeTask.Id, originalEmployeeTask.CreationDate, originalEmployeeTask.ChangeDate).SetChangeDate());
        }
    }
}
