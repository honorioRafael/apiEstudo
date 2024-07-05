using apiEstudo.Application.Arguments.Base;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateEmployeeTask : BaseInputCreate<InputCreateEmployeeTask>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
