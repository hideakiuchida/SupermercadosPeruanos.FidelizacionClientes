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
        private List<CarritoCanje> carritos;
        private CarritoCanje carritoCanje;
        private List<Producto> productos;

        public CarritoCanjeController()
        {
            carritos = new List<CarritoCanje>();
            carritoCanje = new CarritoCanje();
            productos = new List<Producto>();
        }

        // GET: api/CarritoCanje
        public IEnumerable<CarritoCanje> Get()
        {
            return carritos;
        }

        // GET: api/CarritoCanje/5
        public CarritoCanje Get(int id)
        {
            return carritos.Where(x => x.Cliente.Codigo == id).FirstOrDefault();
        }

        // POST: api/CarritoCanje
        public IHttpActionResult Post([FromBody] int id)
        {
            Producto producto = new Producto { Id = id, Descripcion = "Whaever" };                      
            productos.Add(producto);
            carritoCanje.Productos = productos;
            carritoCanje.Cliente = new Cliente { Codigo = id };
            carritos.Add(carritoCanje);
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
