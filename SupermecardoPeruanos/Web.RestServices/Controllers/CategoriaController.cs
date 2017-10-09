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
    public class CategoriaController : ApiController
    {
        private ICategoriaBL categoriaBL;

        public CategoriaController()
        {
            categoriaBL = new CategoriaBL();
        }
        // GET: api/Categoria
        public IEnumerable<Categoria> Get()
        {
            return categoriaBL.GetAll();
        }

        // GET: api/Categoria/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categoria
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Categoria/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Categoria/5
        public void Delete(int id)
        {
        }
    }
}
