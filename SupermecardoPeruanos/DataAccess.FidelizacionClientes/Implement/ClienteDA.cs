using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.FidelizacionClientes.Implement
{
    public class ClienteDA : IClienteDA
    {
        public Cliente GetCliente(string numeroDocumento)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes.Add(new Cliente {
                Codigo = 1,
                Nombre ="Alonso",
                ApellidoPaterno = "Uchida",
                ApellidoMaterno = "Nakasone",
                NumeroDocumentoIdentidad = "43989637",
                Direccion = "Av. Mariano Cornejo 874",
                TipoDocumentoIdentidad = "DNI",
                Sexo="Masculino"
                });
            var cliente = listaClientes.Where(x => x.NumeroDocumentoIdentidad == numeroDocumento).FirstOrDefault();
            return cliente;
        }
    }
}
