﻿using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    public interface IProductoCanjeDA
    {
        CatalogoProducto GetOfertasPersonalizadas(int[] categorias, int cantidad, int pagina);
        Producto Get(int id);
        List<Producto> GetProductosCanje();
        void Insertar(Producto producto);
        void Update(Producto producto);
        void Eliminar(int id);
        List<Producto> GetProductosCarritoCanje(int[] productos);
    }
}
