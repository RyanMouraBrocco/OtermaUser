using OtermaUser.Infra.Sql.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Dtos
{
    public class UserFriendDto : BaseDto
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime FriendShipDate { get; set; }
    }
}
