using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly ITaskRepository _taskRepository;

        public EmployeeRepository(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO>? Get()
        {
            return (from employee in _context.Employees
                    select new EmployeeDTO()
                    {
                        id = employee.id,
                        name = employee.name,
                        task = _taskRepository.GetTask(employee.taskId) 
                    }).ToList();
        }

        public EmployeeDTO? Get(int id)
        {
            return (from employee in _context.Employees
                    where employee.id == id
                    select new EmployeeDTO()
                    {
                        id = employee.id,
                        name = employee.name,
                        task = _taskRepository.GetTask(employee.taskId)
                    })
                    .FirstOrDefault();
        }
        public EmployeeDTO? Get(string name)
        {
            return (from employee in _context.Employees
                    where employee.name.Contains(name)
                    select new EmployeeDTO()
                    {
                        id = employee.id,
                        name = employee.name,
                        task = _taskRepository.GetTask(employee.taskId)
                    })
                    .FirstOrDefault();
        }
    }  
}
