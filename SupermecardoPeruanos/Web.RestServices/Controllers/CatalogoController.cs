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
    public class CatalogoController : ApiController
    {
        private IClienteBL clienteBL;
        private ICatalogoCanjeBL catalogoCanjeBL;

        public CatalogoController()
        {
            clienteBL = new ClienteBL();
            catalogoCanjeBL = new CatalogoCanjeBL();
        }

        public Cliente GetCliente(string id)
        {
            return clienteBL.GetCliente(id);
        }

        // GET: api/Catalogo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Catalogo/5
        public CatalogoProducto Get(int id, int tipo, int cantidad, int pagina)
        {
            return catalogoCanjeBL.GetOfertasPersonalizadas(id, cantidad, pagina);
        }

        // GET: api/Catalogo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Catalogo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Catalogo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Catalogo/5
        public void Delete(int id)
        {
        }
    }
}
