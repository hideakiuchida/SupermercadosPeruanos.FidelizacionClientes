using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class CanjePedido
    {
       public Producto Productos { get; set; }
       public Cliente Cliente { get; set; }
       public int CantidadPuntos { get; set; }
       public int idCliente { get; set; }
       public int[] idProductos { get; set; }
    }
}
