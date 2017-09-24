using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IAfiliacionDA
    {
        AfiliacionTarjetaOH GetByCliente(string numeroDocumento);
        List<Infocorp> GetInfocorpByCliente(string numeroDocumento);
    }
}
