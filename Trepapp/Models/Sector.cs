using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trepapp.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public string UrlImagen { get; set; }
        public string UrlLocalizacion { get; set; }
        public ICollection<Via> Vias { get; set; }

    }
}
