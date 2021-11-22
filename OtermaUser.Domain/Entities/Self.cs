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
        public string Email { get; set; }
        public string Password { get; set; }
        [SpecialProperyUpdate]
        public DateTime CreationDate { get; set; }
        [SpecialProperyUpdate]
        public DateTime UpdateDate { get; set; }
        public IList<UserFriend> Friends { get; set; }
    }
}
