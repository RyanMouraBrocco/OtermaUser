using Microsoft.EntityFrameworkCore;
using OtermaUser.Infra.Sql.Context;
using OtermaUser.Infra.Sql.Dtos.Base;
using OtermaUser.Infra.Sql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Repositories
{
    public class DatabaseRepository<TDto> : IDatabaseRepository<TDto> where TDto : BaseDto
    {
        protected readonly OtermaContext _context;
        protected readonly DbSet<TDto> _dbSet;

        public DatabaseRepository(OtermaContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TDto>();
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public TDto Insert(TDto value)
        {
            _dbSet.Add(value);
            _context.SaveChanges();
            return value;
        }

        public TDto Update(TDto value, IEnumerable<string> updatedFields)
        {
            _dbSet.Attach(value);

            foreach (var updatedField in updatedFields)
            {
                _context.Entry(value).Property(updatedField).IsModified = true;
            }

            _context.SaveChanges();
            return value;
        }

        public TDto UpdateAll(TDto value)
        {
            _dbSet.Update(value);
            _context.SaveChanges();
            return value;
        }

        public TDto Delete(TDto value)
        {
            _dbSet.Remove(value);
            _context.SaveChanges();
            return value;
        }

        public void Dispose()
        {
            _context.Database.CloseConnection();
        }
    }
}
