using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Trepapp.Models
{
    public class Escalador
    {
        public string ID { get; set; }
        public string Nom { get; set; }
        public string Llinatge { get; set; }
        public int Edat { get; set; }
        public string CorreuElectronic { get; set; }
        public bool Federat { get; set; }
    }

    public class EscaladorDBContext : DbContext
    {
        public DbSet<Escalador> Escaladors { get; set; }
    }
}