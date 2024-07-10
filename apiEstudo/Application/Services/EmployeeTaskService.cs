using apiEstudo.Application.Arguments;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application
{
    public class EmployeeTaskService : BaseService<EmployeeTask, IEmployeeTaskRepository, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface) : base(contextInterface)
        { }

        public override long Create(InputCreateEmployeeTask inputCreateEmployeeTask)
        {
            if (inputCreateEmployeeTask == null) 
                throw new ArgumentNullException();
            return _repository.Create(new EmployeeTask(inputCreateEmployeeTask.Name, inputCreateEmployeeTask.Description));
        }

        public override long Update(InputIdentityUpdateEmployeeTask inputIdentityUpdateEmployeeTask)
        {
            if (inputIdentityUpdateEmployeeTask == null) 
                throw new ArgumentNullException();
            var originalEmployeeTask = _repository.Get(inputIdentityUpdateEmployeeTask.Id);
            return _repository.Update(new EmployeeTask(inputIdentityUpdateEmployeeTask.InputUpdate.Name, inputIdentityUpdateEmployeeTask.InputUpdate.Description).LoadInternalData(originalEmployeeTask.Id, originalEmployeeTask.CreationDate, originalEmployeeTask.ChangeDate).SetChangeDate());
        }

        //public bool Update(EmployeeTaskUpdateViewModel view)
        //{
        //    if (view == null) return false;
        //    var Task = _repository.Get(view.Id);
        //    if (Task == null) return false;

        //    Task.Name = view.Name;
        //    Task.Description = view.Description;

        //    _repository.Update(Task);
        //    return true;
        //}
    }
}
