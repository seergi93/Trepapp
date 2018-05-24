using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Trepapp.Models
{
    public class TrepappContext : DbContext
    {
        public TrepappContext (DbContextOptions<TrepappContext> options)
            : base(options)
        {
        }

        public DbSet<Trepapp.Models.Escalador> Escalador { get; set; }
    }
}
