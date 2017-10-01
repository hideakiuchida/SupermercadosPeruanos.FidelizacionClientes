using Business.FidelizacionClientes.Implement;
using Business.FidelizacionClientes.Interfaces;
using Common.FidelizacionClientes;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
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

            Calificacion calificacion = new Calificacion();
            AfiliacionTarjetaOH afiliacion = new AfiliacionTarjetaOH();
            List<Object> _infocorp = new List<object>();

            Cliente cliente = clienteBL.GetCliente(numeroDocumento);
            bool existeCliente = (cliente != null && cliente.Codigo != 0);
            if (existeCliente)
            {
                calificacion = calificacionBL.GetByCliente(cliente.Codigo);
                afiliacion = afiliacionBL.GetByCliente(cliente.Codigo);
                List<Infocorp> infocorp = afiliacionBL.GetInfocorpByCliente(cliente.Codigo);
                _infocorp = new List<Object>();
                infocorp.ForEach(x => _infocorp.Add(new
                {
                    EntidadFinanciera = x.EntidadFinanciera,
                    MontoDeuda = x.MontoDeuda,
                    CalificacionSBS = x.CalificacionSBS
                }));
       
            }

            var data = new
            {
                Cliente = cliente,
                Calificacion = calificacion,
                Afiliacion = afiliacion,
                Infocorp = _infocorp,
                success = existeCliente
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /*
         * Ingresos mayor igual a 2000 para una tarjeta de linea de credido de menor igual a 1000 
            Ingresos mayor igual a 4000 para una tarjeta de linea de credido de menor igual a 2000
            Ingresos mayor igual a 6000 para una tarjeta de linea de credido de menor igual a 3000

            Debe contar con Calificacion SBS A o B

         */
        public JsonResult Evaluar(int codigoCliente)
        {
            ICalificacionBL calificacionBL = new CalificacionBL();
            IAfiliacionBL afiliacionBL = new AfiliacionBL();

            Calificacion calificacion = calificacionBL.GetByCliente(codigoCliente);
            AfiliacionTarjetaOH afiliacion = afiliacionBL.GetByCliente(codigoCliente);
            List<Infocorp> infocorp = afiliacionBL.GetInfocorpByCliente(codigoCliente);

            decimal ingresoTotal = calificacion.SueldoCliente + calificacion.OtrosIngresos;
            bool isCalifica = false;
            string tipo = String.Empty;

            if ((ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoA && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoA) ||
                (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoB && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoB) ||
                (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoC && calificacion.LineaCredito <= CalificacionEnum.LineaCreditoMaximoC))
            {
                foreach (var item in infocorp)
                {
                    isCalifica = item.CalificacionSBS.Equals("1") || item.CalificacionSBS.Equals("2");
                    if (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoC)
                    {
                        tipo = "Black";
                    }
                    else if (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoB)
                    {
                        tipo = "Gold";
                    }
                    else if (ingresoTotal >= CalificacionEnum.SueldoIngresoMinimoA)
                    {
                        tipo = "Plata";
                    }
                }
            }

            var data = new
            {
                EstadoAfiliacion = isCalifica,
                NumeroTarjeta = afiliacion.NumeroTarjeta,
                Tipo = tipo
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarAfiliacion(int codigoCliente, string numero, string tipo)
        {
            IAfiliacionBL afiliacionBL = new AfiliacionBL();

            //afiliacionBL.InsertCliente(codigoCliente, numero, tipo);
            var data = new
            {
                success = 1,
                message = "Se registró existosamente."
            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}