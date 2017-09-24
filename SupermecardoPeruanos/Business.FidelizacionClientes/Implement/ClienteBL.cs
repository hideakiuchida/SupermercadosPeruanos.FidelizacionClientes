using System;
using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Implement
{
    public class ClienteBL : IClienteBL
    {
        private IClienteDA clienteDA;

        public ClienteBL()
        {
            clienteDA = new ClienteDA();
        }

        public Cliente GetCliente(string numeroDocumento)
        {
            return clienteDA.GetCliente(numeroDocumento);
        }
    }
}
