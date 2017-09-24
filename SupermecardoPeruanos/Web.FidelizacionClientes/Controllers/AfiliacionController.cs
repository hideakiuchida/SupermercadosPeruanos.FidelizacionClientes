using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using Common.FidelizacionClientes;
using Model.FidelizacionClientes;
using System;
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
            IClienteBL clienteBL = new ClienteBL();
            ICalificacionBL calificacionBL = new CalificacionBL();
            IAfiliacionBL afiliacionBL = new AfiliacionBL();

            Cliente cliente = clienteBL.GetCliente(numeroDocumento);
            Calificacion calificacion = calificacionBL.GetByCliente(numeroDocumento);
            AfiliacionTarjetaOH afiliacion = afiliacionBL.GetByCliente(numeroDocumento);
            List<Infocorp> infocorp = afiliacionBL.GetInfocorpByCliente(numeroDocumento);
            List<Object> _infocorp = new List<Object>();
            infocorp.ForEach(x => _infocorp.Add(new
            {
                EntidadFinanciera = x.EntidadFinanciera,
                MontoDeuda = x.MontoDeuda,
                CalificacionSBS = x.CalificacionSBS
            })
            );

            var data = new { Cliente = cliente,
                             Calificacion = calificacion,
                             Afiliacion = afiliacion,
                             Infocorp = _infocorp
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /*
         * Ingresos mayor igual a 2000 para una tarjeta de linea de credido de menor igual a 1000 
            Ingresos mayor igual a 4000 para una tarjeta de linea de credido de menor igual a 2000
            Ingresos mayor igual a 6000 para una tarjeta de linea de credido de menor igual a 3000

            Debe contar con Calificacion SBS A o B

         */
        public JsonResult Evaluar(string numeroDocumento)
        {
            ICalificacionBL calificacionBL = new CalificacionBL();
            IAfiliacionBL afiliacionBL = new AfiliacionBL();

            Calificacion calificacion = calificacionBL.GetByCliente(numeroDocumento);
            AfiliacionTarjetaOH afiliacion = afiliacionBL.GetByCliente(numeroDocumento);
            List<Infocorp> infocorp = afiliacionBL.GetInfocorpByCliente(numeroDocumento);

            decimal ingresoTotal = calificacion.SueldoCliente + calificacion.OtrosIngresos;
            bool isCalifica = false;

            if ((ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoA && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoA) ||
                (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoB && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoB) ||
                (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoC && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoC))
            {
                foreach (var item in infocorp)
                {
                    isCalifica = item.CalificacionSBS.Equals("A") || item.CalificacionSBS.Equals("B");
                }
            }

            var data = new
            {
                EstadoAfiliacion = isCalifica,
                NumeroTarjeta = afiliacion.NumeroTarjeta
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}