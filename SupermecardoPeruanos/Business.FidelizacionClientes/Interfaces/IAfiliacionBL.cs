using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IAfiliacionBL
    {
        AfiliacionTarjetaOH GetByCliente(int codigoCliente);
        List<Infocorp> GetInfocorpByCliente(int codigoCliente);
        void InsertCliente(int codigoCliente, string numero, string tipo);
    }
}
