using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeTaskService : BaseService<EmployeeTask, EmployeeTaskDTO>, IEmployeeTaskService
    {
        private readonly IEmployeeTaskRepository _taskRepository;

        public EmployeeTaskService(IEmployeeTaskRepository contextInterface) : base(contextInterface)
        {
            _taskRepository = contextInterface;
        }

        public bool Create(EmployeeTaskViewModel view)
        {
            if (view == null) return false;
            var entity = new EmployeeTask(view.Name, view.Description);
            _taskRepository.Create(entity);
            return true;
        }

        public bool Update(int id, EmployeeTaskViewModel view)
        {
            if (view == null) return false;
            var Task = _taskRepository.Get(id);
            if (Task == null) return false;

            Task.Name = view.Name;
            Task.Description = view.Description;

            _taskRepository.Update(Task);
            return true;
        }
    }
}
