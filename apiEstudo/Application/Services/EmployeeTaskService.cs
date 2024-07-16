﻿using apiEstudo.Application.Arguments;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application
{
    public class EmployeeTaskService : BaseService<EmployeeTask, IEmployeeTaskRepository, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>, IEmployeeTaskService
    {
        public EmployeeTaskService(IEmployeeTaskRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public override List<long> CreateMultiple(List<InputCreateEmployeeTask> listInputCreateEmployeeTask)
        {
            if (listInputCreateEmployeeTask.Count == 0)
                throw new ArgumentNullException();

            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(EmployeeTask)), listInputCreateEmployeeTask.Count);
            var id = idRange.FirstId;

            var employeeTaskToCreate = (from inputCreateEmployeeTask in listInputCreateEmployeeTask
                                        select new EmployeeTaskDTO().Create(id++, inputCreateEmployeeTask)).ToList();
            return _repository.CreateMultiple(employeeTaskToCreate);
        }

        public override List<long> UpdateMultiple(List<InputIdentityUpdateEmployeeTask> listInputIdentityUpdate)
        {
            if (listInputIdentityUpdate.Count == 0)
                throw new ArgumentNullException();

            List<EmployeeTaskDTO> EmployeeTasksToBeUpdated = _repository.GetListByListId((from i in listInputIdentityUpdate select i.Id).ToList());
            if (EmployeeTasksToBeUpdated.Count == 0)
                throw new NotFoundException("EmployeeTask ID não localizado!");

            var employeeTasksToUpdate = InternalUpdate(listInputIdentityUpdate, EmployeeTasksToBeUpdated);
            return _repository.UpdateMultiple(employeeTasksToUpdate);
        }
    }
}
