using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.FidelizacionClientes.Implement
{
    public class CanjePedidoBL : ICanjePedidoBL
    {
        private ICanjePedidoDA canjePedidoDA;

        public CanjePedidoBL()
        {
            canjePedidoDA = new CanjePedidoDA();
        }


        public List<Producto> ObtieneProductosCanje()
        {
            var productos = canjePedidoDA.ObtieneProductosCanje();
            
            return productos;
        }

        public void DeleteItem(int id)
        {
            canjePedidoDA.EliminarItem(id);
        }

        public void InsertarPedidoCanje(CanjePedido canje)
        {
            canjePedidoDA.InsertarCanjePedido(canje);
        }
        public List<CanjePedido> ListarCanjePedido(int id)
        {
            return canjePedidoDA.ListarCanjePedido(id);
        }

        public List<CanjePedido> ListarCanjePedido()
        {
            throw new NotImplementedException();
        }
    }
}
