using Microsoft.EntityFrameworkCore;
using OtermaUser.Infra.Sql.Context;
using OtermaUser.Infra.Sql.Dtos;
using OtermaUser.Infra.Sql.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Repositories
{
    public class UserRepository : DatabaseRepository<UserDto>, IUserRepository
    {
        public UserRepository(OtermaContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserDto> GetOtherUserByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().Where(x => x.Id == id).Select(u => new UserDto() { Id = u.Id, Name = u.Name }).FirstOrDefaultAsync();
        }

        public async Task<UserDto> GetOtherUserByEmailAsync(string email)
        {
            return await _dbSet.AsNoTracking().Where(x => x.Email == email).Select(u => new UserDto() { Id = u.Id, Name = u.Name }).FirstOrDefaultAsync();
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
