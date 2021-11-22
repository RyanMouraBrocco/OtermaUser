using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtermaUser.Api.Controllers.Base;
using OtermaUser.Application.Interfaces;
using OtermaUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Api.Controllers
{
    public class SelfController : BaseController
    {
        private readonly ISelfService _selfService;

        public SelfController(ISelfService selfService)
        {
            _selfService = selfService;
        }

        [HttpGet]
        [Authorize()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _selfService.GetAsync(GetUserId()));
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] Self user)
        {
            return Ok(await _selfService.CreateAsync(user));
        }

        [HttpPatch()]
        [Authorize()]
        public async Task<IActionResult> Patch([FromBody] Self body)
        {
            return Ok(await _selfService.UpdateAsync(GetUserId(), body, RequestBody.Select(x => x.Key)));
        }
    }
}
