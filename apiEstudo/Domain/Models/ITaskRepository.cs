using apiEstudo.Domain.DTOs;

namespace apiEstudo.Domain.Models
{
    public interface ITaskRepository
    {
        List<TaskDTO>? GetTask();
        TaskDTO? GetTask(int id);
    }
}
