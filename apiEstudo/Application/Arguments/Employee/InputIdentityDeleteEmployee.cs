﻿using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteEmployee : BaseInputIdentityDelete<InputIdentityDeleteEmployee>
    {
        public InputIdentityDeleteEmployee(int id) : base(id)
        { }
    }
}
