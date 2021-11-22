using OtermaUser.Domain.Entities.Base;
using System;

namespace OtermaUser.Domain.Entities
{
    public class UserFriend : BaseEntity
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime FriendShipDate { get; set; }
    }
}