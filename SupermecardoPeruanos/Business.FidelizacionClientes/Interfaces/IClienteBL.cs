using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IClienteBL
    {
        Cliente GetCliente(string numeroDocumento);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int codigo);
        List<Cliente> GetClientes(int? dapartamentoId, bool? tieneVeaClub, bool? tieneTarjetaOH);
    }
}
