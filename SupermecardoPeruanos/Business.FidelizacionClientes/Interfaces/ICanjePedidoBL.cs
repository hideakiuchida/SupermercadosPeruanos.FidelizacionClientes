using System.Collections.Generic;
using Model.FidelizacionClientes;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface ICanjePedidoBL
    {
        void DeleteItem(int id);
        void InsertarPedidoCanje(CanjePedido canje);
        List<CanjePedido> ListarCanjePedido();
    }
}