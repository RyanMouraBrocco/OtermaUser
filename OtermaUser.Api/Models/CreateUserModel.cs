using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Api.Models
{
    public class CreateUserModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Max characters is 200")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Max characters is 200")]
        public string Email { get; set; }
        [StringLength(400, ErrorMessage = "Max characters is 400")]
        public string Password { get; set; }
    }
}
