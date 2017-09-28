using Model.FidelizacionClientes;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface ICalificacionDA
    {
        Calificacion GetByCliente(int codigoCliente);
    }
}
