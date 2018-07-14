using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface ICanjePedidoDA
    {
        List<Producto> ObtieneProductosCanje();
        void EliminarItem(int id);
        void InsertarCanjePedido(CanjePedido canje);
        List<CanjePedido> ListarCanjePedido(int id);
    }
}