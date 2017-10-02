using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IAfiliacionDA
    {
        AfiliacionTarjetaOH GetByCliente(int codigoCliente);
        List<Infocorp> GetInfocorpByCliente(int codigoCliente);
        void InsertCliente(int codigoCliente, string numero, string tipo);
        void UpdateSolicitudDes(int numeroDocumento);
        string consultarEstadoSol(string numeroDocumento);


    }
}
