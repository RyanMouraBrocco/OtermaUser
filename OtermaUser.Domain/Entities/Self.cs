using OtermaUser.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Domain.Entities
{
    public class Self : User
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Max characters is 200")]
        public string Email { get; set; }
        [StringLength(400, ErrorMessage = "Max characters is 400")]
        public string Password { get; set; }
        [SpecialProperyUpdate]
        public DateTime CreationDate { get; set; }
        [SpecialProperyUpdate]
        public DateTime UpdateDate { get; set; }
        public IList<UserFriend> Friends { get; set; }
    }
}
