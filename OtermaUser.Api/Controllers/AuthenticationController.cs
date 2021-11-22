using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtermaUser.Api.Controllers.Base;
using OtermaUser.Application.Interfaces;
using OtermaUser.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Api.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticationRequest body)
        {
            return Ok(await _authenticationService.LoginAsync(body));
        }
    }
}
