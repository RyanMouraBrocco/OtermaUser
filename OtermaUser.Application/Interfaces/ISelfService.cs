using OtermaUser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Application.Interfaces
{
    public interface ISelfService
    {
        Task<Self> GetAsync(int userId);
        Task<Self> CreateAsync(Self user);
        Task<Self> UpdateAsync(int userId, Self user, IEnumerable<string> frontSentFields);
    }
}
