using OtermaUser.Application.Helpers;
using OtermaUser.Application.Interfaces;
using OtermaUser.Domain.Attributes;
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
    public class SelfService : ISelfService
    {
        private readonly IUserRepository _userRepository;

        public SelfService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Self> GetAsync(int userId)
        {
            return (await _userRepository.GetByIdAsync(userId)).MapToSelf();
        }

        public async Task<Self> CreateAsync(Self user)
        {
            var otherUserWithSameEmailCheck = (await _userRepository.GetOtherUserByEmailAsync(user.Email))?.MapToUser();
            if (otherUserWithSameEmailCheck != null)
            {
                throw new UnauthorizedAccessException("This email is already used");
            }

            user.CreationDate = DateTime.Now;
            user.Password = Utils.Hash(user.Password);

            var insertedUser = _userRepository.Insert(user.MapToDto()).MapToSelf();

            return insertedUser;
        }

        public async Task<Self> UpdateAsync(int userId, Self user, IEnumerable<string> frontSentFields)
        {
            var updatedFields = Utils.GetFieldsToUpdate<Self>(frontSentFields);
            user.Id = userId;
            user.UpdateDate = DateTime.Now;

            if (updatedFields.Any(x => x.Equals("Email")))
            {
                var userWithSameEmailCheck = (await _userRepository.GetOtherUserByEmailAsync(user.Email)).MapToSelf();
                if (userWithSameEmailCheck != null && !userWithSameEmailCheck.Id.Equals(userId))
                {
                    throw new UnauthorizedAccessException("This email is already used");
                }
            }

            if (updatedFields.Any(x => x.Equals("Password")))
                user.Password = Utils.Hash(user.Password);

            var updatedUser = _userRepository.Update(user.MapToDto(), updatedFields).MapToSelf();
            return updatedUser;
        }
    }
}
