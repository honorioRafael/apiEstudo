﻿namespace apiEstudo.Application.Arguments
{
    public class InputCreateEmployee : BaseInputCreate<InputCreateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long EmployeeTaskId { get; set; }
    }
}
