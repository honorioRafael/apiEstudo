using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeDTO>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public bool Update(int id, EmployeeViewModel view)
        {
            if (view == null) return false;
            var employee = _employeeRepository.Get(id);
            if (employee == null) return false;

            employee.Name = view.Name;
            employee.Age = view.Age;
            employee.EmployeeTaskId = view.taskId;

            _employeeRepository.Update(employee);
            return true;

        }

        public bool Create(EmployeeViewModel View)
        {
            if (View == null) return false;

            var entity = new Employee(View.Name, View.Age, View.taskId);
            _employeeRepository.Create(entity);
            return true;
        }
    }
}
