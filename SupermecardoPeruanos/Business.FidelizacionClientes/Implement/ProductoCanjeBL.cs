using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.FidelizacionClientes.Implement
{
    public class ProductoCanjeBL : IProductoCanjeBL
    {
        private IProductoCanjeDA productoCanjeDA;

        public ProductoCanjeBL()
        {
            productoCanjeDA = new ProductoCanjeDA();
        }

        public void Delete(int id)
        {
            productoCanjeDA.Eliminar(id);
        }

        public Producto Get(int id)
        {
            return productoCanjeDA.Get(id);
        }

        public List<Producto> GetProductosCanje(int? tipoId, int? categoriaId)
        {
            var productos = productoCanjeDA.GetProductosCanje();
            if (productos.Any() && (tipoId.HasValue))
                productos = productos.Where(x => x.TipoCanjeId == tipoId).ToList();

            if (productos.Any() && (categoriaId.HasValue))
                productos = productos.Where(x => x.CategoriaId == categoriaId).ToList();

            return productos;
        }

        public void Insertar(Producto producto)
        {
            productoCanjeDA.Insertar(producto);
        }

        public void Update(Producto producto)
        {
            productoCanjeDA.Update(producto);
        }
    }
}
