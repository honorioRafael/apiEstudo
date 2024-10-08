﻿using Study.Arguments.Arguments;
using Study.Arguments.CustomException;
using Study.Arguments.CustomFunction;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Base;

namespace Study.Domain.Service
{
    public class EmployeeService : BaseService<IEmployeeRepository, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTaskRepository employeeTaskRepository, IIdControlRepository idControlRepository) : base(employeeRepository, idControlRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        private readonly IEmployeeTaskRepository _employeeTaskRepository;

        public override List<long> CreateMultiple(List<InputCreateEmployee> listInputCreateEmployee)
        {
            if (listInputCreateEmployee.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeTaskDTO>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputCreateEmployee select i.EmployeeTaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Employee Task ID inválido!");
            if (listInputCreateEmployee.Any(x => x.Age < 0))
                throw new InvalidArgumentException("Há uma idade inválida na lista de atualização.");

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId("Employee"), listInputCreateEmployee.Count);
            var id = idRange.FirstId;

            var employeesToCreate = (from inputCreateEmployee in listInputCreateEmployee
                                     select new EmployeeDTO().Create(id++, inputCreateEmployee)).ToList();
            return _repository.CreateMultiple(employeesToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateEmployee> listInputIdentityUpdateEmployee)
        {
            if (listInputIdentityUpdateEmployee.Count == 0)
                throw new ArgumentNullException();
            if (listInputIdentityUpdateEmployee.Any(x => x.InputUpdate.Age < 0))
                throw new InvalidArgumentException("Idade inválida!");

            List<EmployeeTaskDTO>? listRelatedTasks = _employeeTaskRepository.GetListByListId((from i in listInputIdentityUpdateEmployee select i.InputUpdate.EmployeeTaskId).ToList());
            if (listRelatedTasks == null || listRelatedTasks.Count == 0)
                throw new NotFoundException("Há um ID de Tarefa inválido na lista de atualização!");

            List<EmployeeDTO>? employeesToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdateEmployee select i.Id).ToList());
            if (employeesToBeUpdated == null || employeesToBeUpdated.Count != listInputIdentityUpdateEmployee.Count)
                throw new NotFoundException("Há um ID de Funcionário inválido na lista de atualização.");

            var updatedEmployees = (from inputIdentityUpdateEmployee in listInputIdentityUpdateEmployee
                                    let inputUpdateEmployee = inputIdentityUpdateEmployee.InputUpdate
                                    let employeeToUpdate = (from j in employeesToBeUpdated where j.InternalPropertiesDTO.Id == inputIdentityUpdateEmployee.Id select j).FirstOrDefault()
                                    select employeeToUpdate.Update(inputUpdateEmployee)).ToList();
            return _repository.UpdateMultiple(updatedEmployees);
        }
    }
}
