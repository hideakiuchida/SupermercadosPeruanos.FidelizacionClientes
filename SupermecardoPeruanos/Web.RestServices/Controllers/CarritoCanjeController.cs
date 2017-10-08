using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Web.RestServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CarritoCanjeController : ApiController
    {
        // GET: api/CarritoCanje
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CarritoCanje/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CarritoCanje
        public IHttpActionResult Post([FromBody] int id)
        {
            Producto producto = new Producto { Id = id, Descripcion = "Whaever" };
            CarritoCanje carritoCanje = new CarritoCanje();
            List<Producto> productos = new List<Producto>();
            productos.Add(producto);
            carritoCanje.Productos = productos;
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/CarritoCanje/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CarritoCanje/5
        public void Delete(int id)
        {
        }
    }
}
