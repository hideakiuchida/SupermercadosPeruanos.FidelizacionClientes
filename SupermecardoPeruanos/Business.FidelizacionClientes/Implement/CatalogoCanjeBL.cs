using Business.FidelizacionClientes.Interfaces;
using DataAccess.FidelizacionClientes.Implement;
using DataAccess.FidelizacionClientes.Interfaces;
using Model.FidelizacionClientes;
using System.Linq;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Implement
{
    public class CatalogoCanjeBL : ICatalogoCanjeBL
    {
        private IHistorialCompraDA historialCompraDA;
        private IProductoCanjeDA productoCanjeDA;

        public CatalogoCanjeBL()
        {
            historialCompraDA = new HistorialCompraDA();
            productoCanjeDA = new ProductoCanjeDA();
        }

        public CatalogoProducto GetOfertasPersonalizadas(int idCliente, int cantidad, int pagina)
        {
            List<HistorialCompra> listaHistorialCompra = historialCompraDA.GetByCliente(idCliente);
            var lista =  listaHistorialCompra.GroupBy(x => x.Categoria.Id)
                .Select(x => new { IdCategoria = x.Key, Cantidad = x.Sum(item => item.Codigo)})
                .OrderByDescending(x => x.Cantidad)
                .Take(3);

            int[] categorias = lista!=null ? lista.Select(x => x.IdCategoria).ToArray() : new int[0];

            return productoCanjeDA.GetOfertasPersonalizadas(categorias, cantidad, pagina);
        }
    }
}
