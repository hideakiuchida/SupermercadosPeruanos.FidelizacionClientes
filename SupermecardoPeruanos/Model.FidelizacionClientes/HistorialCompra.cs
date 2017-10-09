using System;
using System.Collections.Generic;
using System.Text;

namespace Model.FidelizacionClientes
{
    public class HistorialCompra
    {
        public int Codigo { get; set; }
        public decimal ImporteCompra { get; set; }

        public Categoria Categoria { get; set; }
        public Producto Producto { get; set; }
        public Cliente Cliente { get; set; }
    }
}
