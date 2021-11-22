using OtermaUser.Api.Models;
using OtermaUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Api.Mappers
{
    public static class SelfMapper
    {
        public static Self Map(this CreateUserModel model)
        {
            return new Self()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }

        public static Self Map(this UpdateUserModel model)
        {
            return new Self()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };
        }
    }
}
