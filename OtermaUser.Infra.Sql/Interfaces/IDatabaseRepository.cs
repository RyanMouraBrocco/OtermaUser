using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Interfaces
{
    public interface IDatabaseRepository<TDto> : IDisposable
    {
        Task<TDto> GetByIdAsync(int id);
        TDto Insert(TDto value);
        TDto Update(TDto value, IEnumerable<string> updatedFields);
        TDto UpdateAll(TDto value);
        TDto Delete(TDto value);
    }
}
