﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace apiEstudo.Domain.DTOs
{
    public class EmployeeTaskDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}