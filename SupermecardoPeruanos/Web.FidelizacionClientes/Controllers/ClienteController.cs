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
    public class ClienteController : Controller
    {
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

        [HttpGet]
        public JsonResult ObtenerCliente(string numeroDocumento)
        {
            IClienteBL clienteBL = new ClienteBL();

            var cliente = clienteBL.GetCliente(numeroDocumento);

            var data = new
            {
                success = cliente != null,
                cliente = cliente
            };

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Registrar(Cliente cliente)
        {
            try
            {
                IClienteBL clienteBL = new ClienteBL();
                bool success;
                string mensaje;
                cliente.Estado = "ACTIVO";
                
                if (!isMayorEdad(cliente.FechaNacimiento))
                {
                    success = false;
                    mensaje = "No es mayor de edad.";
                }
                else
                {
                    clienteBL.InsertCliente(cliente);
                    success = true;
                    mensaje = "Se registro satisfactoriamente";
                }
                   
                var data = new
                {
                    success = success,
                    mensaje = mensaje
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }        
        }

        [HttpPost]
        public JsonResult Editar(Cliente cliente)
        {
            try
            {
                IClienteBL clienteBL = new ClienteBL();
                clienteBL.UpdateCliente(cliente);

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
        public JsonResult Eliminar(string numeroDocumento)
        {
            try
            {
                IClienteBL clienteBL = new ClienteBL();
                Cliente cliente = new Cliente();
                cliente.NumeroDocumentoIdentidad = numeroDocumento;
                cliente.Estado = "INACTIVO";
                clienteBL.UpdateCliente(cliente);

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


        private bool isMayorEdad(DateTime fechaNacimiento)
        {
            var edad = (DateTime.Now - fechaNacimiento).TotalDays/365;
            return edad >= 18;
        }

    }
}
