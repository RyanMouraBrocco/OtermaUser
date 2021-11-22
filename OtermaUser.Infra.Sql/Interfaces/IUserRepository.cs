using OtermaUser.Infra.Sql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Interfaces
{
    public interface IUserRepository : IDatabaseRepository<UserDto>
    {
        Task<UserDto> GetOtherUserByIdAsync(int id);
        Task<UserDto> GetOtherUserByEmailAsync(string email);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
