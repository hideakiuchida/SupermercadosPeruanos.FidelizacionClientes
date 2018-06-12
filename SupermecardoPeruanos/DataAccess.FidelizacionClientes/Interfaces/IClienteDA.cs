﻿using Model.FidelizacionClientes;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IClienteDA
    {
        Cliente GetCliente(string numeroDocumento);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int codigo);
        Cliente ListCliente();
    }
}
