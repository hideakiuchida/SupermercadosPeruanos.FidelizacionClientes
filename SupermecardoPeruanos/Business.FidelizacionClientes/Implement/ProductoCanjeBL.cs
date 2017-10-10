using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;

namespace Business.FidelizacionClientes.Implement
{
    public class ProductoCanjeBL : IProductoCanjeBL
    {
        private IProductoCanjeDA productoCanjeDA;

        public ProductoCanjeBL()
        {
            productoCanjeDA = new ProductoCanjeDA();
        }
        public Producto Get(int id)
        {
            return productoCanjeDA.Get(id);
        }
    }
}
