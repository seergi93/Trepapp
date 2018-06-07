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

        internal List<Sector> getSector(int id)
        {
            return context.Sector.Where(c => c.SectorId == id).ToList();

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

        internal List<IdentityError> editarVia(int id, string nombre, string descripcion, string grado, int sectorId, int funcion)
        {
            var via = new Via()
            {
                ViaId = id,
                Nombre = nombre,
                Descripcion = descripcion,
                Grado = grado,
                SectorId = sectorId
            };
            try
            {
                context.Update(via);
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

        internal List<Via> getVias(int id)
        {
            return context.Via.Where(c => c.ViaId == id).ToList();
        }

        public List<object[]> filtrarVia(int numPagina, string valor, string order)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 10;
            int can_paginas, pagina;
            string dataFilter = "", paginador = "";
            List<object[]> data = new List<object[]>();
            IEnumerable<Via> query;
            List<Via> sectores = null;

            switch (order.ToLower())
            {
                case "nombre":
                    sectores = context.Via.OrderBy(c => c.Nombre).ToList();
                    break;
                case "grado":
                    sectores = context.Via.OrderBy(c => c.Grado).ToList();
                    break;
                case "sector":
                    sectores = context.Via.OrderBy(c => c.Sector).ToList();
                    break;
                case "sectorId":
                    sectores = context.Via.OrderBy(c => c.SectorId).ToList();
                    break;

                default:
                    break;
            }
            numRegistros = sectores.Count;
            inicio = (numPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);
            if (valor == "null")
            {
                query = sectores.Skip(inicio).Take(reg_por_pagina);
            }
            else
            {
                query = sectores.Where(c => c.Nombre.StartsWith(valor) ||
                c.Grado.StartsWith(valor) || c.SectorId.ToString().Contains(valor));
            }
            cant = query.Count();

            foreach (var item in query)
            {
                var sector = getSector(item.SectorId);

                dataFilter += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Descripcion + "</td>" +
                    "<td>" + item.Grado + "</td>" +
                    "<td>" + sector[0].Nombre + "</td>" +
                    "<td>" +
                    "<a data-toggle='modal' data-target='#modalCS' onclick='editarVia(" + item.ViaId + ',' + 1 + ")'  class='btn btn-success'>Edit</a>" +
                    "</td>" +
                //   "<td>" +
                //  getInstructorsCurso(item.CursoID)
                //    "</td>" +
                "</tr>";

            }
            object[] dataObj = { dataFilter, paginador };
            data.Add(dataObj);
            return data;
        }

    }
}

