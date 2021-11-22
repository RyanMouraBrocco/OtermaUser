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
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("ById/{id}")]
        [Authorize()]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }
    }
}
