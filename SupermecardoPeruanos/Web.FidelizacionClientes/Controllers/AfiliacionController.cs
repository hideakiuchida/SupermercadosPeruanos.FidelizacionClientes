﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.FidelizacionClientes.Controllers
{
    public class AfiliacionController : Controller
    {
        // GET: Afiliacion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscarAfiliacionCliente(string numeroDocumento)
        {
            var data = new { NumeroDocumento = numeroDocumento };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}