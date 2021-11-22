using OtermaUser.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
    }
}
