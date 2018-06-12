using Model.FidelizacionClientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.FidelizacionClientes.Interfaces
{
    interface IStockCanjeDA
    {
        StockCanje GetByProducto(int codigoProducto);
    }
}
