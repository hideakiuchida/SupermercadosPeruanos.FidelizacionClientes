using Model.FidelizacionClientes;
using System.Collections.Generic;

namespace Business.FidelizacionClientes.Interfaces
{
    public interface IProductoCanjeBL
    {
        Producto Get(int id);
        List<Producto> GetProductosCanje(int? tipoId, int? categoriaId);
        List<Producto> ListaProducto();
        void Insertar(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
        List<Producto> GetProductosCarritoCanje(int[] productos);

    }
}
