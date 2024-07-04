﻿using apiEstudo.Application.ViewModelInterfaces;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ViewModel
{
    public class EmployeeTaskViewModel : BaseViewModel<EmployeeTask>, IEmployeeTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
