using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OtermaUser.Application.Helpers;
using OtermaUser.Application.Interfaces;
using OtermaUser.Domain.Authentication;
using OtermaUser.Domain.Authentication.Settings;
using OtermaUser.Domain.Entities;
using OtermaUser.Infra.Sql.Interfaces;
using OtermaUser.Infra.Sql.Mappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticationSettings Settings { get; set; }
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository, IOptions<AuthenticationSettings> options)
        {
            _userRepository = userRepository;
            Settings = options.Value;
        }

        public async Task<AuthenticationToken> LoginAsync(AuthenticationRequest authenticationRequest)
        {
            var hashedPassord = Utils.Hash(authenticationRequest.Password);
            var userCheck = (await _userRepository.GetByEmailAsync(authenticationRequest.Email))?.MapToSelfAuthentication();
            if (userCheck == null || !userCheck.Password.Equals(hashedPassord))
            {
                throw new UnauthorizedAccessException("Email or password not found");
            }

            return new AuthenticationToken(GenerateJsonToken(userCheck));
        }

        private string GenerateJsonToken(Self user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            var token = new JwtSecurityToken(Settings.Issuer, Settings.Issuer, claims, expires: DateTime.Now.AddMinutes(Settings.ExpirationTimeInMinutes), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
