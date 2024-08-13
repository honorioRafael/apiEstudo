using Study.Arguments.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Arguments.Arguments
{
    public class InputCreateUser : BaseInputCreate<InputCreateUser>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public InputCreateUser() { }
    }
}
