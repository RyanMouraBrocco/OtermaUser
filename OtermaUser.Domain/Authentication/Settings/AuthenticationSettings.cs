using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Domain.Authentication.Settings
{
    public class AuthenticationSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTimeInMinutes { get; set; }
    }
}
