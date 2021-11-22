using OtermaUser.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationToken> LoginAsync(AuthenticationRequest authenticationRequest);
    }
}
