using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IHistorialCompraDA
    {
        List<HistorialCompra> GetByCliente(int id);
    }
}
