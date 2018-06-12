using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class StockCanje
    {
        public int Codigo { get; set; }
        public double Stock { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Producto Producto { get; set; }
    }
}
