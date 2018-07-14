using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.CanjePuntos.Models;

namespace Web.CanjePuntos.Controllers
{
    public class CanjePedidoController : Controller
    {
        private CanjePedido canjePedido;
        // GET: CanjePedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmarPedidoCanje()
        {
            return View();
        }
        public JsonResult GuardarItem(int idProducto)
        {
            CarModel viewmodel = new CarModel();
            viewmodel.CargarDatos();
            var retorno = viewmodel.AddItem(idProducto);
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

    }
}