using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.EmployeeTaskViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeTaskService : BaseService<EmployeeTask, IEmployeeTaskRepository, EmployeeTaskDTO>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface) : base(contextInterface)
        { }
        public bool Create(EmployeeTaskCreateViewModel view)
        {
            if (view == null) return false;
            var entity = new EmployeeTask(view.Name, view.Description);
            _repository.Create(entity);
            return true;
        }

        public bool Update(EmployeeTaskUpdateViewModel view)
        {
            if (view == null) return false;
            var Task = _repository.Get(view.Id);
            if (Task == null) return false;

            Task.Name = view.Name;
            Task.Description = view.Description;
            Task.ChangeDate = DateTime.Now;

            _repository.Update(Task);
            return true;
        }
    }
}
