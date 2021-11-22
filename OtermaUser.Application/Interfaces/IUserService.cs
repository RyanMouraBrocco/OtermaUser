using OtermaUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int userId);
    }
}
