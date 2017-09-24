using System.Linq;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class CalificacionDA : ICalificacionDA
    {
        public Calificacion GetByCliente(string numeroDocumento)
        {
            List<Calificacion> listaCalificacion = new List<Calificacion>();
            listaCalificacion.Add(new Calificacion
            {
                Codigo = 1,
                CalificacionCrediticia = "Sin Deuda",
                LineaCredito = 2000,
                SueldoCliente = 4000,
                OtrosIngresos = 2000,
                Estado = "Aprobado",
                Cliente = new Cliente
                {
                    Codigo = 1,
                    Nombre = "Alonso",
                    ApellidoPaterno = "Uchida",
                    ApellidoMaterno = "Nakasone",
                    NumeroDocumentoIdentidad = "43989637",
                    Direccion = "Av. Mariano Cornejo 874",
                    TipoDocumentoIdentidad = "DNI",
                    Sexo = "Masculino"
                }
            });
            var calificacion = listaCalificacion.Where(x => x.Cliente.NumeroDocumentoIdentidad == numeroDocumento).FirstOrDefault();
            return calificacion;
        }
    }
}
