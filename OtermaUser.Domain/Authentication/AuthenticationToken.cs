using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Domain.Authentication
{
    public class AuthenticationToken
    {
        public string Token { get; set; }

        public AuthenticationToken(string token)
        {
            Token = token;
        }
    }
}
