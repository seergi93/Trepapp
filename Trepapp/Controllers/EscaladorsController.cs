using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trepapp.Models;

namespace Trepapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Escalador")]
    public class EscaladorsController : Controller
    {

        List<Escalador> escaladors = new List<Escalador>() {
         new Escalador {
          ID = 1, Contrasenya = "blablabla", DataNeixament = new DateTime(1993, 04, 04), Nick = "gas", NomILlinatges = "pepepepe adsada sadas"
         },
         new Escalador {
          ID = 2, Contrasenya = "blablabla", DataNeixament = new DateTime(1993, 04, 04), Nick = "gas", NomILlinatges = "pepepepe adsada sadas"
         },
         new Escalador {
          ID = 3, Contrasenya = "blablabla", DataNeixament = new DateTime(1993, 04, 04), Nick = "gas", NomILlinatges = "pepepepe adsada sadas"
         }
        };

        // GET: api/Escalador

        private TrepappDbContext db = new TrepappDbContext();

        [HttpGet]
        public IEnumerable<Escalador> Get()
        {
            return db.Escalador;
        }

        // GET: api/Escalador/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Escalador
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Escalador/5
        [HttpPut("{id}")]
        public ActionResult Put(Escalador esc)
        {
            db.Escalador.Add(esc);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {


            //    services.AddMvc();

            //    services.AddDbContext<MvcEscaladorContext>(options =>
            //            options.UseSqlServer(GetConfiguration.GetConnectionString("MvcEscaladorContext")));
        }

        public class MvcEscaladorContext
        {

        }
    }
}
