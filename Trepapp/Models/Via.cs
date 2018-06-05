using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trepapp.Models
{
    public class Via
    {
        public int ViaId { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        public Sector Sector { get; set; }
        public int SectorId { get; set; }
    }
}