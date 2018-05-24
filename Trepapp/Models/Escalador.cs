using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trepapp.Models
{
    public class Escalador
    {
        public int ID { get; set; }
        public string NomILlinatges { get; set; }
        public string Contrasenya { get; set; }
        public string Nick { get; set; }
        public DateTime DataNeixament { get; set; }

    }

    public class TrepappDbContext : DbContext
    {
        public TrepappDbContext()
        {

        }
        public DbSet<Escalador> Escalador
        {
            get; set;

        }
    }
}
