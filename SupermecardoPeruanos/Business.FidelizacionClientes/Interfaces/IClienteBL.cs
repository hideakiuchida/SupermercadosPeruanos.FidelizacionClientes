using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IClienteBL
    {
        Cliente GetCliente(string numeroDocumento);
    }
}
