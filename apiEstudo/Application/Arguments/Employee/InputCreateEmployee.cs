using apiEstudo.Application.Arguments.Base;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

namespace apiEstudo.Application.Arguments
{
    public class InputCreateEmployee : BaseInputCreate<InputCreateEmployee>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int TaskId { get; set; }
    }
}
