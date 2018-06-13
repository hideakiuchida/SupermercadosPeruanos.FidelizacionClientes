﻿using System;
using System.Collections.Generic;
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
        public void InsertCliente(Cliente cliente)
        {
            clienteDA.InsertCliente(cliente);
        }
        public void UpdateCliente(Cliente cliente)
        {
            clienteDA.UpdateCliente(cliente);
        }
        public void DeleteCliente(int codigo)
        {
            clienteDA.DeleteCliente(codigo);
        }

        public List<Cliente> GetClientes(int? dapartamentoId, bool? tieneVeaClub, bool? tieneTarjetaOH)
        {
            return clienteDA.GetClientes(dapartamentoId, tieneVeaClub, tieneTarjetaOH);
        }
    }
}
