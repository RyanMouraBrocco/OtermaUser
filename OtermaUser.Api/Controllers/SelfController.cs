using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtermaUser.Api.Controllers.Base;
using OtermaUser.Api.Mappers;
using OtermaUser.Api.Models;
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
        public async Task<IActionResult> Post([FromBody] CreateUserModel user)
        {
            return Ok(await _selfService.CreateAsync(user.Map()));
        }

        [HttpPatch()]
        [Authorize()]
        public async Task<IActionResult> Patch([FromBody] UpdateUserModel body)
        {
            return Ok(await _selfService.UpdateAsync(GetUserId(), body.Map(), RequestBody.Select(x => x.Key)));
        }
    }
}
