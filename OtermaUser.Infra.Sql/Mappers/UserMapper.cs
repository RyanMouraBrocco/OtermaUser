using OtermaUser.Domain.Entities;
using OtermaUser.Infra.Sql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Mappers
{
    public static class UserMapper
    {
        public static User MapToUser(this UserDto dto)
        {
            return new User()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static Self MapToSelf(this UserDto dto)
        {
            return new Self()
            {
                Id = dto.Id,
                Name = dto.Name,
                CreationDate = dto.CreationDate,
                Email = dto.Email,
                UpdateDate = dto.UpdateDate
            };
        }

        public static UserDto MapToDto(this Self entity)
        {
            return new UserDto()
            {
                Id = (int)entity.Id,
                Name = entity.Name,
                CreationDate = entity.CreationDate,
                Email = entity.Email,
                Password = entity.Password,
                UpdateDate = entity.UpdateDate
            };
        }
    }
}
