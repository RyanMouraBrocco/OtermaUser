using Microsoft.EntityFrameworkCore;
using OtermaUser.Infra.Sql.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaUser.Infra.Sql.Context
{
    public class OtermaContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }

        public OtermaContext(DbContextOptions<OtermaContext> options) : base(options)
        {

        }
    }
}
