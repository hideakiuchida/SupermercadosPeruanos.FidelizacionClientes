using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IClienteBL
    {
        Cliente GetCliente(string numeroDocumento);
        void InsertCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int codigo);
        Cliente ListCliente();
    }
}
