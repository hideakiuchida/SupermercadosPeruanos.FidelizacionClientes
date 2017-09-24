using Model.FidelizacionClientes;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IClienteDA
    {
        Cliente GetCliente(string numeroDocumento);
    }
}
