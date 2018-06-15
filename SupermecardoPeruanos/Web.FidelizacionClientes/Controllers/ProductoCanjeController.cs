using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.FidelizacionClientes.Controllers
{
    public class ProductoCanjeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerProductosCanje(int? tipoId, int? categoriaId)
        {
            IProductoCanjeBL productoCanjeBL = new ProductoCanjeBL();

            var productos = productoCanjeBL.GetProductosCanje(tipoId, categoriaId);

            var data = new
            {
                success = productos.Any(),
                productos = productos
            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ObtenerProductoCanje(int id)
        {
            IProductoCanjeBL productoCanjeBL = new ProductoCanjeBL();

            var producto = productoCanjeBL.Get(id);

            var data = new
            {
                success = producto != null,
                producto = producto
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerCategorias()
        {
            ICategoriaBL categoriaBL = new CategoriaBL();

            var categorias = categoriaBL.GetAll();

            var data = new
            {
                success = categorias.Any(),
                categorias = categorias
            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Registrar(Producto producto)
        {
            try
            {
                IProductoCanjeBL productoCanjeBL = new ProductoCanjeBL();

                productoCanjeBL.Insertar(producto);

                var data = new
                {
                    success = true,
                    mensaje = "Se registro satisfactoriamente"
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Editar(Producto producto)
        {
            try
            {
                IProductoCanjeBL productoCanjeBL = new ProductoCanjeBL();
                productoCanjeBL.Update(producto);

                var data = new
                {
                    success = true,
                    mensaje = "Se actualizó satisfactoriamente"
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                IProductoCanjeBL productoCanjeBL = new ProductoCanjeBL();
                productoCanjeBL.Delete(id);

                var data = new
                {
                    success = true,
                    mensaje = "Se eliminó satisfactoriamente"
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
