﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Base;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers
{
    public class ShippingStatusController : BaseController_1<IShippingStatusService, OutputShippingStatus>
    {
        public ShippingStatusController(IShippingStatusService service) : base(service) { }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override ActionResult<OutputShippingStatus> Get(long id)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(BaseInputIdentityUpdate_0 inputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete(BaseInputIdentityDelete_0 inputIdentityDelete)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Create(BaseInputCreate_0 inputCreate)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult CreateMultiple(List<BaseInputCreate_0> listInputCreate)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult UpdateMultiple(List<BaseInputIdentityUpdate_0> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult DeleteMultiple(List<BaseInputIdentityDelete_0> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }
    }
}
