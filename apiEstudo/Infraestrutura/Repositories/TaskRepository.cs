using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public List<TaskDTO>? GetTask()
        {
            return (from task in _context.Tasks
                    select new TaskDTO()
                    {
                        taskName = task.taskName,
                        taskDescription = task.taskDescription
                    }).ToList();
        }

        public TaskDTO? GetTask(int id)
        {
            return(from task in _context.Tasks
                   where task.id == id
                    select new TaskDTO()
                    {
                        taskName = task.taskName,
                        taskDescription = task.taskDescription
                    }).FirstOrDefault();
        }
    }
}
