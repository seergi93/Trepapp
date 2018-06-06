using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Trepapp.Data;

namespace Trepapp.Models
{
    public class ViaModels
    {
        private ApplicationDbContext context;
        private List<IdentityError> errorList = new List<IdentityError>();
        private string code = "", des = "";

        public ViaModels(ApplicationDbContext context)
        {
            this.context = context;
        }

        internal List<Sector> getSectores()
        {
            return context.Sector.ToList();

        }

        internal List<IdentityError> agregarVia(int id, string nombre, string descripcion, string grado, int sector, string funcion)
        {
            var via = new Via
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Grado = grado,
                SectorId = sector
            };
            try
            {
                context.Add(via);
                context.SaveChanges();
                code = "Save";
                des = "Save";
            }
            catch (Exception e)
            {

                code = "error";
                des = e.Message;
            }
            errorList.Add(new IdentityError
            {
                Code = code,
                Description = des
            });
            return errorList;
        }
    }
}

