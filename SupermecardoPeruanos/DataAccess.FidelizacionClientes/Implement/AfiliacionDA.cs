using System.Linq;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System.Collections.Generic;
using System;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class AfiliacionDA : IAfiliacionDA
    {
        Cliente cliente = new Cliente
        {
            Codigo = 1,
            Nombre = "Alonso",
            ApellidoPaterno = "Uchida",
            ApellidoMaterno = "Nakasone",
            NumeroDocumentoIdentidad = "43989637",
            Direccion = "Av. Mariano Cornejo 874",
            TipoDocumentoIdentidad = "DNI",
            Sexo = "Masculino"
        };

        public AfiliacionTarjetaOH GetByCliente(string numeroDocumento)
        {
            List<AfiliacionTarjetaOH> lista = new List<AfiliacionTarjetaOH>();
            lista.Add(new AfiliacionTarjetaOH
            {
              Codigo = 1,
              Tipo = "Credito",
              NumeroTarjeta = "8767-2342-3423-4323",
              Bin = "404",
              Cliente = cliente
            });
            var afiliacion = lista.Where(x => x.Cliente.NumeroDocumentoIdentidad == numeroDocumento).FirstOrDefault();
            return afiliacion;
        }

        public List<Infocorp> GetInfocorpByCliente(string numeroDocumento)
        {
            List<Infocorp> lista = new List<Infocorp>();
            lista.Add(new Infocorp
            {
                EntidadFinanciera = "BCP",
                MontoDeuda = 5000,
                CalificacionSBS = "A",
                Cliente = cliente
            });
            lista.Add(new Infocorp
            {
                EntidadFinanciera = "Interbank",
                MontoDeuda = 400,
                CalificacionSBS = "A",
                Cliente = cliente
            });
            lista.Add(new Infocorp
            {
                EntidadFinanciera = "Scotiabank",
                MontoDeuda = 7000,
                CalificacionSBS = "B",
                Cliente = cliente
            });
            var infocorp = lista.Where(x => x.Cliente.NumeroDocumentoIdentidad == numeroDocumento).ToList();
            return infocorp;
        }
    }
}
