using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Api.Models
{
    public class UpdateUserModel
    {
        [AllowNull]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Max characters is 200")]
        public string Name { get; set; }
        [AllowNull]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Max characters is 200")]
        public string Email { get; set; }
        [AllowNull]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Max characters is 12 and min is 8")]
        public string Password { get; set; }
    }
}
