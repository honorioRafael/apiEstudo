﻿using apiEstudo.Application.Arguments.BaseViewModel;

namespace apiEstudo.Application.Arguments
{
    public class InputIdentityDeleteBrand : BaseInputIdentityDelete<InputIdentityDeleteBrand>
    {
        public InputIdentityDeleteBrand(int id) : base(id) { }
    }
}