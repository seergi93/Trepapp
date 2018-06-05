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
        public string Descripcion { get; set; }
        public string Grado { get; set; }
        public Sector Sector { get; set; }
<<<<<<< HEAD
        public int SectorÏd { get; set; }
=======
        public int SectorId { get; set; }
>>>>>>> e93f61c89dc91c64b34677d76ae0e96d0196b43c
    }
}