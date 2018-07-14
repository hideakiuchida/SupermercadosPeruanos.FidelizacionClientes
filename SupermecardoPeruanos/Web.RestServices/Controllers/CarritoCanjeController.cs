using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
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
        private List<CanjePedido> carritos;
        private CanjePedido carritoCanje;
        private List<Producto> productos;
        private IProductoCanjeBL productoCanjeBL; 
        public CarritoCanjeController()
        {
            carritos = new List<CanjePedido>();
            carritoCanje = new CanjePedido();
            productos = new List<Producto>();
            productoCanjeBL = new ProductoCanjeBL();
        }

        // GET: api/CarritoCanje
        public IEnumerable<Producto> Get([FromUri]int[] ids)
        {
            return productoCanjeBL.GetProductosCarritoCanje(ids);// GetProductosCarritoCanje(ids);
        }
        //[Route("GetProductosByIds")]
        //public IEnumerable<Producto> GetProductosByIds([FromUri]int?[] ids)
        //{
        //    return productoCanjeBL.GetProductosCarritoCanje(ids);
        //}

        //GET: api/CarritoCanje/5
        public CanjePedido Get(int id)
        {
            return carritos.Where(x => x.Cliente.Codigo == id).FirstOrDefault();
        }

        // POST: api/CarritoCanje
        public IHttpActionResult Post([FromBody] int id)
        {
            Producto producto = new Producto { Id = id, Descripcion = "Whaever" };
            productos.Add(producto);
            //carritoCanje.Productos = productos;
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
