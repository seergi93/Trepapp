using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trepapp.Data;

namespace Trepapp.Models
{
    public class ViaModels
    {
        private ApplicationDbContext context;

        public ViaModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Sector> getSectores()
        {
            return context.Sector.ToList();

        }

    }
}
