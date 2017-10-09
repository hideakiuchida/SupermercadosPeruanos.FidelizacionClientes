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
            /* CatalogoProducto catalogoProducto = new CatalogoProducto();
             List<Producto> productos = new List<Producto>();
             productos.Add(new Producto { Id=1, Imagen= "Content/Images/pic_mountain.jpg", Categoria=new Categoria { Id =1, Descripcion="Musica"}, Puntos = 1000 });
             productos.Add(new Producto { Id = 2, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 1, Descripcion = "Musica" }, Puntos = 1000 });
             productos.Add(new Producto { Id = 3, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 2, Descripcion = "Musica" }, Puntos = 2000 });
             productos.Add(new Producto { Id = 4, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 2, Descripcion = "Musica" }, Puntos = 3000 });
             productos.Add(new Producto { Id = 5, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 2, Descripcion = "Musica" }, Puntos = 4000 });
             productos.Add(new Producto { Id = 6, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 3, Descripcion = "Musica" }, Puntos = 5000 });
             productos.Add(new Producto { Id = 7, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 4, Descripcion = "Musica" }, Puntos = 1000 });
             productos.Add(new Producto { Id = 8, Imagen = "Content/Images/pic_mountain.jpg", Categoria = new Categoria { Id = 4, Descripcion = "Musica" }, Puntos = 2000 });
             catalogoProducto.Productos = productos;
             catalogoProducto.Total = productos.Count;*/
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
