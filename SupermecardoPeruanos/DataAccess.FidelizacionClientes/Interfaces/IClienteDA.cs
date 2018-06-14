using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IClienteDA
    {
        Cliente GetCliente(string numeroDocumento);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        List<Cliente> GetClientes();
    }
}
