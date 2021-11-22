using OtermaUser.Application.Interfaces;
using OtermaUser.Domain.Entities;
using OtermaUser.Infra.Sql.Interfaces;
using OtermaUser.Infra.Sql.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return (await _userRepository.GetOtherUserByIdAsync(userId)).MapToUser();
        }
    }
}
