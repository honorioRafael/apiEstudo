﻿using apiEstudo.Application.ViewModel.EmployeeViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IEmployeeService : IBaseService<Employee, EmployeeDTO>
    {
        public bool Update(EmployeeUpdateViewModel view);
        public bool Create(EmployeeCreateViewModel view);
    }
}
