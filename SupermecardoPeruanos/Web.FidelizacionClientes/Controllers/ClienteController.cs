using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.FidelizacionClientes.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerClientes(int? dapartamentoId, bool? tieneVeaClub, bool? tieneTarjetaOH)
        {
            IClienteBL clienteBL = new ClienteBL();

            var clientes = clienteBL.GetClientes(dapartamentoId, tieneVeaClub, tieneTarjetaOH);

            var data = new
            {
                success = clientes.Any(),
                clientes = clientes
            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}
